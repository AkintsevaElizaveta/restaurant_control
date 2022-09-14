import TablesApi from "../TablesApi";

export default class Tables{
    #list

    fetch() {
        return TablesApi.getList().then((list) => {
            this.setList(list);
        })
    }

    setList(list) {
        this.#list = list;
    }

    getList() {
        return this.#list;
    }
}