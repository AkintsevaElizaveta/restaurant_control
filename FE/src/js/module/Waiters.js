import WaitersApi from "../WaitersApi";

export default class Waiters{
    #list

    fetch() {
        return WaitersApi.getList().then((list) => {
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