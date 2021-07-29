import React, {useContext, useEffect, useState} from 'react';
import * as Realm from "realm-web"
import {getRealmApp} from '../getRealmApp';

// Access the Realm App.
const app = getRealmApp();

// Create a new Context object that will be provided to descendants of
// the AuthProvider.
const AuthContext = React.createContext(null);

let mongodb;
let database;
const AuthProvider = ({children}) => {
    const [user, setUser] = useState(app.currentUser);

    useEffect(() => {
        if(!user) {
            return null;
        }
    })

    // The signIn function takes an email and password and uses the
    // emailPassword authentication providers to log in.
    const signIn = async (email, password) => {
        // Create an anonymous credential
        const credentials = Realm.Credentials.emailPassword(email, password);
        try {
            // Authenticate the user
            const newLogin = await app.logIn(credentials);
            setUser(newLogin);
            mongodb = app.currentUser.mongoClient('mongodb-atlas');
            database = mongodb.db('AlterEgo');
        } catch (err) {
            return "erreur lors de la connection";
        }
    };

    // The signUp function takes an email and password and uses the
    // emailPassword authentication providers to register the user.
    const signUp = async (email, password) => {
        await app.emailPasswordAuth.registerUser(email, password);
    };

    // The signOut function calls the logOut function on the currently
    // logged in user
    const signOut = () => {
        if (user == null) {
            console.warn("Not logged in, can't log out!");
            return;
        }
        user.logOut().then((r) => setUser(null));
    };

    const resetPassword = async(email, password) => {
        await app.resetPassword(email, password);
    }

    const addPlayer = async (tag, email) => {
        mongodb = app.currentUser.mongoClient('mongodb-atlas');
        database = mongodb.db('AlterEgo');
        const player = database.collection('Player');
        await player.insertOne({
            _id: user.id,
            tag: tag,
            email: email
        }).catch((err) => console.error(`Failed to insert item: ${err}`));
    }

    const fetchAllSkins = async () => {
        mongodb = app.currentUser.mongoClient('mongodb-atlas');
        database = mongodb.db('AlterEgo');
        const skins = database.collection('Skin');
        return await skins.find().catch((err) => console.error(`Failed to read item: ${err}`));
    }

    const fetchPlayerSkins = async () => {
        mongodb = app.currentUser.mongoClient('mongodb-atlas');
        database = mongodb.db('AlterEgo');
        const player = database.collection('Player');
        return await player.findOne({_id: {eq: user.id}});
    }

    const playerBuySkin = async (skin) => {
        mongodb = app.currentUser.mongoClient('mongodb-atlas');
        database = mongodb.db('AlterEgo');
        const player = database.collection('Player');
        const item = { skinId: skin, unlocked: true};
        const query = {_id: {eq: user.id}};
        const update = {
            $push: {
                skins: item,
            }
        }
        await player.updateOne(query, update).catch((err) => console.error(`Failed to insert item: ${err}`));
    }

    return (
        <AuthContext.Provider
            value={{
                user,
                signIn,
                signUp,
                signOut,
                resetPassword,
                addPlayer,
                fetchAllSkins,
                fetchPlayerSkins,
                playerBuySkin,
            }}>
            {children}
        </AuthContext.Provider>
    )
}

// The useAuth hook can be used by components under an AuthProvider to
// access the auth context value.
const useAuth = () => {
    const auth = useContext(AuthContext);
    if (auth == null) {
        throw new Error('useAuth() called outside of a AuthProvider?');
    }
    return auth;
};

export {AuthProvider, useAuth}
