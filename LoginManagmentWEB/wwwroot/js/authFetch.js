window.authFetch = {
    getJson: async function (url) {
        const token = localStorage.getItem('token') || '';
        const res = await fetch(url, {
            method: 'GET',
            headers: token ? { 'Authorization': 'Bearer ' + token } : {}
        });
        if (!res.ok) {
            const text = await res.text();
            throw new Error(`${res.status} ${res.statusText} - ${text}`);
        }
        return res.json();
    },

    postJson: async function (url, body) {
        const token = localStorage.getItem('token') || '';
        const headers = { 'Content-Type': 'application/json' };
        if (token) headers['Authorization'] = 'Bearer ' + token;
        const res = await fetch(url, {
            method: 'POST',
            headers,
            body: JSON.stringify(body)
        });
        if (!res.ok) {
            const text = await res.text();
            throw new Error(`${res.status} ${res.statusText} - ${text}`);
        }
        return res.json();
    },

    putJson: async function (url, body) {
        const token = localStorage.getItem('token') || '';
        const headers = { 'Content-Type': 'application/json' };
        if (token) headers['Authorization'] = 'Bearer ' + token;
        const res = await fetch(url, {
            method: 'PUT',
            headers,
            body: JSON.stringify(body)
        });
        if (!res.ok) {
            const text = await res.text();
            throw new Error(`${res.status} ${res.statusText} - ${text}`);
        }
        return res.ok;
    },

    deleteJson: async function (url) {
        const token = localStorage.getItem('token') || '';
        const res = await fetch(url, {
            method: 'DELETE',
            headers: token ? { 'Authorization': 'Bearer ' + token } : {}
        });
        if (!res.ok) {
            const text = await res.text();
            throw new Error(`${res.status} ${res.statusText} - ${text}`);
        }
        return res.ok;
    }
};