import CategoriesApi from "../api/CategoriesApi";

export default class Categories {

    #categories

    fetch() {
        return CategoriesApi.getCategories().then((categories) => {
            this.setList(categories);
        })
    }

    setList(categories) {
        this.#categories = categories;
    }

    getCategories() {
        return this.#categories;
    }
}