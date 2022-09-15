import Tables from "../model/Tables";
import TablesView from "../view/TablesView";

export default class TablesController{
    #$rootContainer;

    constructor($container) {
        this.#$rootContainer = $container;
        this.collection = new Tables();
        this.tablesView = new TablesView({
            onSelect: id => console.log(`'table id'${id}`)
        })

        this.tablesView.appendTo(this.#$rootContainer);
        this.collection.fetch()
            .then(() => this.renderList())
    }

    renderList() {
        this.tablesView.renderTablesList(this.collection.getList());
    }
}