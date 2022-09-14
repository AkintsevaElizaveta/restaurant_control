import $ from 'jquery';

export default class WaitersView {
    static WAITERS_LIST_SELECTOR = '#waitersList';
    static WAITERS_ITEM_SELECTOR = '.waiters_item'

    #$list;
    #options;

    constructor(options) {
        this.#$list = $(WaitersView.WAITERS_LIST_SELECTOR)
            .on('click', WaitersView.WAITERS_ITEM_SELECTOR, (e) => this.onWaitersListClick(e))

        this.#options = options;
    }

    onWaitersListClick(e){
        e.preventDefault();

        const id = this.getTableId(e.target);

        this.#options.onSelect(id);
    }

    renderWaitersList(list) {
        const html = list.map(list => this.generateHtmlWaiters(list)).join('');
        this.#$list.append(html);
    }

    appendTo($el) {
        $el.append(this.#$list);
    }

    getTableId(el) {
        return el.closest(WaitersView.WAITERS_ITEM_SELECTOR)?.dataset.id;
    }

    generateHtmlWaiters(waiter){
        return ` 
        <li class="waiters_item" data-id="${waiter.id}">
            <strong>
            ${waiter.name}
            </strong>
            <img class="waiters_item_photo" src="${waiter.photoUrl}" alt="photo">
        </li>
    `;
    }
}