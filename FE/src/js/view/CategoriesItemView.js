import $ from 'jquery';

export default class CategoriesItemView {
    static CATEGORY_LIST_SELECTOR = '.dish_list';
    static CATEGORY_ITEM_SELECTOR = '.dish_item'

    #$list;
    #options;

    constructor(options) {
        this.#$list = $(CategoriesItemView.CATEGORY_LIST_SELECTOR)
            .on('click', CategoriesItemView.CATEGORY_ITEM_SELECTOR, (e) => this.onItemsListClick(e))

        this.#options = options;
    }

    onItemsListClick(e){
        e.preventDefault();

        const id = this.geItemId(e.target);

        this.#options.onSelect(id);
    }

    renderCategoryItems(list) {
        this.#$list.html('');

        const html = list.map(list => this.generateHtmlCategoryItems(list)).join('');

        this.#$list.append(html);
    }

    appendTo($el) {
        $el.append(this.#$list);
    }

    geItemId(el) {
        return el.closest(CategoriesItemView.CATEGORY_ITEM_SELECTOR)?.dataset.id;
    }

    generateHtmlCategoryItems(item){
        return ` 
        <li class="dish_item" data-id="${item.id}">
            <strong class="dish_item_title">
            ${item.name}
            </strong>
            <img src="${item.photoUrl}" alt="" class="dish_item_photo">
            <span>${item.price} ₴</span>
            <button class="dish_item_add">
                <svg xmlns="http://www.w3.org/2000/svg" class="bi bi-plus-circle dish_item_add_icon" viewBox="0 0 16 16">
                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg>
            </button>
        </li>
    `;
    }
}