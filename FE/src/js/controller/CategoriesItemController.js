import CategoriesItem from "../model/CategoriesItem";
import CategoriesItemView from "../view/CategoriesItemView";

export default class CategoriesItemController{
    #$rootContainer;

    constructor($container) {
        this.#$rootContainer = $container;
        this.collection = new CategoriesItem();
        this.categoriesItemView = new CategoriesItemView({
            // onSelect: id => this.collection.fetch(id)
            //     .then(() => this.renderList(id))
        })

        this.categoriesItemView.appendTo(this.#$rootContainer);
    }

    renderList() {
        this.categoriesItemView.renderCategoryItems(this.collection.getItems());
    }

    loadItemsOfCategory(id){
        this.collection.fetch(id).then(() => this.renderList())
    }
}