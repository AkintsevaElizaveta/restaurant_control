import $ from 'jquery';

export default class CategoriesView {
    static CATEGORIES_LIST_SELECTOR = '.dish_category';
    static CATEGORIES_ITEM_SELECTOR = '.dish_category_item'

    #$list;
    #options;

    constructor(options) {
        this.#$list = $(CategoriesView.CATEGORIES_LIST_SELECTOR)
            .on('click', CategoriesView.CATEGORIES_ITEM_SELECTOR, (e) => this.onCategoriesListClick(e))

        this.#options = options;
    }

    onCategoriesListClick(e){
        e.preventDefault();

        const id = this.getCategoryId(e.target);

        this.#options.onSelect(id);
    }

    renderCategoriesList(list) {
        const html = list.map(list => this.generateHtmlCategories(list)).join('');
        this.#$list.append(html);
    }

    appendTo($el) {
        $el.append(this.#$list);
    }

    getCategoryId(el) {
        return el.closest(CategoriesView.CATEGORIES_ITEM_SELECTOR)?.dataset.id;
    }

    generateHtmlCategories(category){
        return ` 
        <li class="dish_category_item" data-id="${category.id}">
            <strong>
            ${category.name}
            </strong>
             <button class="open_category_btn">
                <svg xmlns="http://www.w3.org/2000/svg" class="bi bi-plus-circle open_category_btn_icon" viewBox="0 0 16 16">
                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg>
             </button>
        </li>
    `;
    }
}