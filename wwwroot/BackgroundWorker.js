// Import for the side effect of defining a global 'browser' variable
import * as _ from "/content/Blazor.BrowserExtension/lib/browser-polyfill.min.js";
browser.runtime.onInstalled.addListener(() => {
    const indexPageUrl = browser.runtime.getURL("options.html");
  browser.tabs.create({
    url: indexPageUrl
  });
});
browser.alarms.clearAll();
const delayInMinutes = 0.1;
const periodInMinutes = 0.2;
browser.alarms.onAlarm.addListener(async () => {
    /*const indexPageUrl = browser.runtime.getURL("index.html");
    browser.tabs.create({
        url: indexPageUrl
    });*/
    //let xhr = new XMLHttpRequest();
    //xhr.open('GET', 'sed.rr22.local:8080/api/auth/checkAuth?token=64a38f2554093a530954cdeb__5ba6273180e8cee86b0a9c8be63d023c__ff65cedc-5fa0-44f9-bef4-99b6606ffa60', [async, null, null]);
    //xhr.send(null);
    let token = '';
    await browser.storage.local.get("token").then((result) => {
        token = result.token;
    },
        (error) => {
            console.log(error)
        });
    let nowDate = new Date(Date.now());
    let day_ago = new Date(Date.now());
    let day_later = new Date(Date.now());
    day_ago.setDate(day_ago.getDate() - 1);
    day_later.setDate(day_later.getDate() + 1);
    let month_ago = new Date(Date.now());
    month_ago.setMonth(month_ago.getMonth() - 1);
    let month_later = new Date(Date.now());
    month_later.setMonth(month_later.getMonth() + 1);
    let body =
    {
        "documentTypes": [
            5,
            7,
            3,
            1,
            4,
            8,
            6
        ],
        "periodFilter": "4",
        "termless": "0",
        "onlyResolutions": false,
        "controlTypes": [
            "without_control",
            "og_control",
            "special_control",
            "removed_from_control"
        ],
        "from": `${day_ago.getFullYear()}-${('0' + (day_ago.getMonth() + 1)).slice(-2)}-${('0' + day_ago.getDate()).slice(-2) }T00:00:00.000+03:00`,
        "to": `${day_later.getFullYear()}-${('0' + (day_later.getMonth() + 1)).slice(-2)}-${('0' + day_later.getDate()).slice(-2) }T00:00:00.000+03:00`,
        "createFrom": `${nowDate.getFullYear()}-01-01T00:00:00.000+03:00`,
        "createTo": `${nowDate.getFullYear()}-${('0' + (nowDate.getMonth() + 1)).slice(-2)}-${ ('0' + nowDate.getDate()).slice(-2)}T00:00:00.000+03:00`,
        "numerators": [],
        "documentSubType": null,
        "statuses": [
            50
        ],
        "onPerformanceExpired": false,
        "onPerformanceNotExpired": true,
        "executedExpired": false,
        "executedNotExpired": false,
        "controlType": 0,
        "departmentControl": 7,
        "otherUserId": "64bf397c6e4354b45ea2bb8c",
        "otherUser": {
            "fio": "Селектор Селектор Селектор",
            "departmentName": null,
            "sectionName": "06 Отдел эксплуатации информационных систем, технических средств и каналов связи"
        },
        "controlSignType": 0,
        "token": token
    }
    let url = `http://sed.rr22.local:8080/api/auth/checkAuth?token=${token}`;
    //console.log(JSON.stringify(body));
    let response = await fetch('http://sed.rr22.local:8080/api/task/taskControl', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
    if (response.ok) {
        let need_docs = [];
        let gabage_flag = false;
        let result = await response.json();
        for (let i = 0; i < result.length; i++) {
            let doc = result[i];
            let signers = doc.signers;
            let to_flag = true;
            let signers_flag = true;
            for (let j = 0; j < signers.length; j++) {
                if (signers[j].surname == 'Ахременко') {
                    signers_flag = true;
                    break;
                }
            }
            //to_flag = doc.commissionSubject.toLowerCase() == 'техническое обеспечение';
            if (to_flag && signers_flag) {
                let currDate = Date.now();
                let dt = new Date(currDate);
                if (~doc.dateForExecution.indexOf(`${dt.getFullYear()}-${('0' + (dt.getMonth() + 1)).slice(-2)}-${('0' + dt.getDate()).slice(-2) }`)) {
                    gabage_flag = true;
                }
                need_docs.push(doc);
            }
        }
        if (gabage_flag) {
            browser.action.setBadgeText({ text: "!" });
            browser.action.setBadgeBackgroundColor({ color: "red" });
        }
        else
        {
            browser.action.setBadgeText({ text: "0" });
            browser.action.setBadgeBackgroundColor({ color: "green" });
        }
        let tasks = need_docs;
        browser.storage.local.set({ tasks }).then(() => console.log(JSON.stringify(tasks)), () => console.log("error"));
    } else {
        console.log(response.status);
    }

    /*response = await fetch(url);
    if (response.ok) {
        let json = await response.text();
        let authCheck = {
            statusCode: response.status,
        }
        browser.storage.local.set(authCheck).then(() => {
            console.log("authCheck is set");
        });
        }
        else
            browser.storage.local.set({ answer: 'Error ' + response.status });*/


        /*await browser.cookies.set({
            answer: json,
        });*/
        /*function setItem() {
            console.log("OK");
        }

        function gotKitten(item) {
            console.log(`${item.kitten.name} has ${item.kitten.eyeCount} eyes`);
        }

        function gotMonster(item) {
            console.log(`${item.monster.name} has ${item.monster.eyeCount} eyes`);
        }

        function onError(error) {
            console.log(error);
        }

        // define 2 objects
        let monster = {
            name: "Kraken",
            tentacles: true,
            eyeCount: 10,
        };

        let kitten = {
            name: "Moggy",
            tentacles: false,
            eyeCount: 2,
        };

        // store the objects
        browser.storage.local.set({ kitten, monster }).then(setItem, onError);

        browser.storage.local.get("kitten").then(gotKitten, onError);
        browser.storage.local.get("monster").then(gotMonster, onError);*/
    //let kavo = xhr.responseText;
});
browser.alarms.create("auth-check", { delayInMinutes, periodInMinutes });
// сизова ел04617 от 10 мая таблица