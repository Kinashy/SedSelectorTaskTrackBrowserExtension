const cacheNamePrefix = 'offline-cache-';
const cacheName = `selector`;
const offlineAssetsInclude = [/\.dll$/, /* /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/ */];
const offlineAssetsExclude = [/^service-worker\.js$/];

function blob2uint(blob) {
    return new Response(blob).arrayBuffer().then(buffer => {
        uint = [...new Uint8Array(buffer)];
        return uint;
    });
}

window.fetch = new Proxy(window.fetch, {
    async apply(actualFetch, that, args)
    {
        if (args[0].includes("/framework/")) {
            let request = args[0];
            if (localStorage.getItem(request)) {
                console.log("kavo");
                return new Promise((resolve, reject) => {
                    resolve(new Blob([new Uint8Array(browser.storage.local.getItem(request).split(','))], { type: "application/x-msdownload"}))
                })
            } else {
                // получить данные
                let result = "";
                let parasha =
                {
                    key: "value"
                }
                //console.log("kavo");
                Reflect.apply(actualFetch, that, args).then((data) => { data.blob().then(val => { blob2uint(val).then(v => { browser.storage.local.set(parasha).then(() => { console.log("Value is set"); }); }) }) });
                return Reflect.apply(actualFetch, that, args);
            }
        }
        else
        {
            let result = Reflect.apply(actualFetch, that, args);
            return result;
        }
    }
});