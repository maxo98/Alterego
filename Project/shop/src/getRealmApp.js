import * as Realm from "realm-web"

let app;

// Returns the shared instance of the Realm app.
export function getRealmApp() {
    if (app === undefined) {
        const appId = 'alterego-shop-xcuog';
        const appConfig = {
            id: appId,
            timeout: 100000,
            app: {
                name: 'default',
                version: '0',
            },
        };
        app = new Realm.App(appConfig);
    }
    return app;
}
