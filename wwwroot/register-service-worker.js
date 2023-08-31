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

class ResBlob extends Blob
{
    ok;
}

window.fetch = new Proxy(window.fetch, {
    async apply(actualFetch, that, args)
    {
        if (
            args[0].endsWith("Blazor.BrowserExtension.dll.br") ||
            args[0].endsWith("JsBind.Net.Extensions.DependencyInjection.dll.br") ||
            args[0].endsWith("Microsoft.AspNetCore.Components.Web.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Configuration.Abstractions.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Configuration.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Configuration.Json.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.DependencyInjection.Abstractions.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.DependencyInjection.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Logging.Abstractions.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Logging.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Options.dll.br") ||
            args[0].endsWith("Microsoft.Extensions.Primitives.dll.br") ||
            args[0].endsWith("Microsoft.JSInterop.dll.br") ||
            args[0].endsWith("Microsoft.JSInterop.WebAssembly.dll.br") ||
            args[0].endsWith("netstandard.dll.br") ||
            args[0].endsWith("System.Buffers.dll.br") ||
            args[0].endsWith("System.Collections.Concurrent.dll.br") ||
            args[0].endsWith("System.Collections.dll.br") ||
            args[0].endsWith("System.Collections.Specialized.dll.br") ||
            args[0].endsWith("System.ComponentModel.Annotations.dll.br") ||
            args[0].endsWith("System.ComponentModel.dll.br") ||
            args[0].endsWith("System.Linq.dll.br") ||
            args[0].endsWith("System.Linq.Queryable.dll.br") ||
            args[0].endsWith("System.Memory.dll.br") ||
            args[0].endsWith("System.Net.Http.Json.dll.br") ||
            args[0].endsWith("System.Net.Primitives.dll.br") ||
            args[0].endsWith("System.ObjectModel.dll.br") ||
            args[0].endsWith("System.Runtime.dll.br") ||
            args[0].endsWith("System.Runtime.InteropServices.JavaScript.dll.br") ||
            args[0].endsWith("System.Runtime.Serialization.Primitives.dll.br") ||
            args[0].endsWith("System.Text.Encodings.Web.dll.br") ||
            args[0].endsWith("WebExtensions.Net.Extensions.DependencyInjection.dll.br")
            )
        {
            //console.log(args[0]);
            let typeOfContent = "application/x-msdownload";
            if (args[0].includes("dotnet.wasm")) {
                typeOfContent = "application/wasm";
            }
            let request = args[0];
            let ret = new Promise((resolve, reject) =>
            {
                chrome.storage.local.get(request).then((req) =>
                {
                    if (req[request] != null) {
                        let bl = new ResBlob([new Uint8Array(req[request])], { type: typeOfContent });
                        bl.ok = true;
                        resolve(bl)
                    }
                    else
                    {
                        var dataObj = {};
                        Reflect.apply(actualFetch, that, args).then((data) => {
                            data.blob().then(val => {
                                blob2uint(val).then(v => {
                                    dataObj[request] = v;
                                    chrome.storage.local.set(dataObj).then((ret) => {
                                        let bl = new ResBlob([new Uint8Array(dataObj[request])], { type: typeOfContent });
                                        bl.ok = data.ok;
                                        resolve(bl);
                                    });
                                });
                            })
                        })
                    }
                });
            })
            return ret;
        }
        else
        {
            let result = Reflect.apply(actualFetch, that, args);
            return result;
        }
    }
});
