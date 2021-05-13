import axios from "axios";

const client = axios.create({
    baseURL: "http://localhost:5000/cards",
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
    get(cardId) {
        return this.execute("get", `/${cardId}`);
    },
    update(id, data) {
        return this.execute("put", `/${id}`, data);
    },
    delete(id) {
        return this.execute("delete", `/${id}`);
    },
};
