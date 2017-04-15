interface AuthConfiguration {
    clientID: string;
    domain: string;
    callbackURL: string;
}

export const myConfig: AuthConfiguration = {
    clientID: 'sNh9iJaRtDfpNkkZG4drJylQfGW1MK9D',
    domain: 'asd1531.eu.auth0.com',
    // You may need to change this!
    callbackURL: 'http://localhost:4200/'
};