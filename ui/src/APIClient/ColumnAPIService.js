import axios from "axios";

const client = axios.create({
    baseURL: "http://localhost:5000/columns",
});

export default {
    async execute(method, resource, data) {
        return client({
            method,
            url: resource,
            data,
        }).then((req) => {
            return req.data;
        });
    },
    update(id, data) {
        return this.execute("put", `/${id}`, data);
    },
    delete(id) {
        return this.execute("delete", `/${id}`);
    },
    getCards(id) {
        return this.execute("get", `/${id}/cards`);
    },
    createCard(id, data) {
        return this.execute("post", `/${id}/cards`, data);
    },
};
