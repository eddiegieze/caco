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
    getAll(columnId) {
        return this.execute("get", `/${columnId}`);
    },
    create(columnId, data) {
        return this.execute("post", `/${columnId}`, data);
    },
    update(id, data) {
        return this.execute("put", `/${id}`, data);
    },
    delete(id) {
        return this.execute("delete", `/${id}`);
    },
};
