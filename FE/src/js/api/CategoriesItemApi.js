export default class CategoriesItemApi{

    static ROOT_URI = 'https://restaurantcontrolapi20220912132901.azurewebsites.net/menuitems/category/';

    static request(url = '', method = 'GET', body) {
        return fetch(this.ROOT_URI + url, {
            method,
            body: body ? JSON.stringify(body) : undefined,
            headers: {
                'Access-Control-Allow-Headers': '*',
                'Content-type': 'application/json',
            },
        })
            .catch((e) => {
                throw new Error(`${e.message}`);
            });
    }

    static getItems(id) {
        return CategoriesItemApi
            .request(id)
            .then(res => {
                if (res.ok) {
                    return res.json();
                }
                console.log(res)
                throw new Error("Can't get the items of category");
            });

    }
}