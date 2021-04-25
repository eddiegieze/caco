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
    getAll(boardId) {
        return this.execute("get", `/${boardId}`);
    },
    create(boardId, data) {
        return this.execute("post", `/${boardId}`, data);
    },
    update(id, data) {
        return this.execute("put", `/${id}`, data);
    },
    delete(id) {
        return this.execute("delete", `/${id}`);
    },
};
