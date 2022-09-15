import CategoriesItemApi from "../api/CategoriesItemApi";

export default class CategoriesItem {
    #items = [];

    fetch(id) {
        return CategoriesItemApi.getItems(id).then((items) => {
            this.setList(items);
        })
    }

    setList(items) {
        this.#items =  items;
    }

    getItems() {
        return this.#items;
    }
}