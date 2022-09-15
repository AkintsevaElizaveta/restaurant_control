import Waiters from "../model/Waiters";
import WaitersView from "../view/WaitersView";

export default class WaitersController{
    #$rootContainer;

    constructor($container) {
        this.#$rootContainer = $container;
        this.collection = new Waiters();
        this.waitersView = new WaitersView({
            onSelect: id => console.log(`'waiter id'${id}`)
        })

        this.waitersView.appendTo(this.#$rootContainer);
        this.collection.fetch()
            .then(() => this.renderList())
    }

    renderList() {
        this.waitersView.renderWaitersList(this.collection.getList());
    }
}