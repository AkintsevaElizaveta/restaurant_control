export default class TablesApi{
    static ROOT_URI = 'https://restaurantcontrolapi20220912132901.azurewebsites.net/tables';

    static request(url = '', method = 'GET', body) {
        return fetch(this.ROOT_URI + url, {
            method,
            body: body ? JSON.stringify(body) : undefined,
            headers: {
                'Content-type': 'application/json',
            },
        })
            .catch((e) => {
                throw new Error(`${e.message}`);
            });
    }

    static getList() {
        return TablesApi
            .request()
            .then(res => {
                if (res.ok) {
                    return res.json();
                }
                throw new Error("Can't get the list");
            });

    }
}