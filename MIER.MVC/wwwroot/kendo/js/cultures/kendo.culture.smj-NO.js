/** 
 * Kendo UI v2021.2.616 (http://www.telerik.com/kendo-ui)                                                                                                                                               
 * Copyright 2021 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/

(function(f){
    if (typeof define === 'function' && define.amd) {
        define(["kendo.core"], f);
    } else {
        f();
    }
}(function(){
(function( window, undefined ) {
    kendo.cultures["smj-NO"] = {
        name: "smj-NO",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": "??",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-%n","%n"],
                decimals: 2,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Norwegian Krone",
                abbr: "NOK",
                pattern: ["$ -n","$ n"],
                decimals: 2,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "kr"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["s??dn??biejvve","m??nnodahka","dijstahka","gasskavahkko","duorastahka","bierjjedahka","l??vvodahka"],
                    namesAbbr: ["s??d","m??n","dis","gas","duor","bier","l??v"],
                    namesShort: ["s","m","d","g","d","b","l"]
                },
                months: {
                    names: ["??d??jakm??nno","guovvam??nno","sjnjuktjam??nno","vuoratjism??nno","moarmesm??nno","biehtsem??nno","sjnjilltjam??nno","b??rggem??nno","rag??tm??nno","g??lg??dism??nno","bas??dism??nno","javllam??nno"],
                    namesAbbr: ["??d??j","guov","snju","vuor","moar","bieh","snji","b??rg","rag??","g??lg","bas??","javl"]
                },
                AM: [""],
                PM: [""],
                patterns: {
                    d: "dd.MM.yyyy",
                    D: "dddd, MMMM d'. b. 'yyyy",
                    F: "dddd, MMMM d'. b. 'yyyy HH:mm:ss",
                    g: "dd.MM.yyyy HH:mm",
                    G: "dd.MM.yyyy HH:mm:ss",
                    m: "MMMM d'. b.'",
                    M: "MMMM d'. b.'",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "MMMM yyyy",
                    Y: "MMMM yyyy"
                },
                "/": ".",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));