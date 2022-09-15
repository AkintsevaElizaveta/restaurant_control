import Categories from "../model/Categories";
import CategoriesView from "../view/CategoriesView";

export default class CategoriesController{
    #$rootContainer;
    #itemsController

    constructor($container, itemsController) {
        this.#$rootContainer = $container;
        this.collection = new Categories();
        this.#itemsController = itemsController;
        this.categoriesView = new CategoriesView({
            onSelect: id => itemsController.loadItemsOfCategory(id)
        })

        this.categoriesView.appendTo(this.#$rootContainer);
        this.collection.fetch()
            .then(() => this.renderList())
    }

    renderList() {
        this.categoriesView.renderCategoriesList(this.collection.getCategories());
    }

}