import $ from 'jquery';

export default class TablesView {
    static TABLES_LIST_SELECTOR = '#tablesList';
    static TABLES_ITEM_SELECTOR = '.tables__item'

    #$list;
    #options;

    constructor(options) {
        this.#$list = $(TablesView.TABLES_LIST_SELECTOR)
       .on('click', TablesView.TABLES_ITEM_SELECTOR, (e) => this.onTablesListClick(e))

        this.#options = options;
    }

    onTablesListClick(e){
        e.preventDefault();

        const id = this.getTableId(e.target);

        this.#options.onSelect(id);
    }

    renderTablesList(list) {
        const html = list.map(list => this.generateHtmlTables(list)).join('');
        this.#$list.append(html);
    }

    appendTo($el) {
        $el.append(this.#$list);
    }

    getTableId(el) {
        return el.closest(TablesView.TABLES_ITEM_SELECTOR)?.dataset.id;
    }

    generateHtmlTables(table){
        return ` 
        <li class="tables__item" data-id="${table.id}" style="grid-area: ${table.positionX}/${table.positionY}/${table.positionX +1}/${table.positionY +1}">
            <strong>
            ${table.number}
            </strong>
        </li>
    `;
    }
}