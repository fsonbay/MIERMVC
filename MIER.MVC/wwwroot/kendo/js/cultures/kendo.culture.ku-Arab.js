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
    kendo.cultures["ku-Arab"] = {
        name: "ku-Arab",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ",",
            ".": ".",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "??"
            },
            currency: {
                name: "",
                abbr: "",
                pattern: ["$-n","$n"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "??.??.???"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["????????????????","????????????????","??????????????","??????????????????","??????????????????","??????????","??????????"],
                    namesAbbr: ["????????????????","????????????????","??????????????","??????????????????","??????????????????","??????????","??????????"],
                    namesShort: ["??","??","??","??","??","??","??"]
                },
                months: {
                    names: ["?????????????? ??????????","??????????","??????????","??????????","??????????","????????????????","????????????","??????","??????????????","???????????? ??????????","???????????? ??????????","???????????? ??????????"],
                    namesAbbr: ["?????????????? ??????????","??????????","??????????","??????????","??????????","????????????????","????????????","??????","??????????????","???????????? ??????????","???????????? ??????????","???????????? ??????????"]
                },
                AM: ["??.??","??.??","??.??"],
                PM: ["??.??","??.??","??.??"],
                patterns: {
                    d: "yyyy/MM/dd",
                    D: "dddd, dd MMMM, yyyy",
                    F: "dddd, dd MMMM, yyyy hh:mm:ss tt",
                    g: "yyyy/MM/dd hh:mm tt",
                    G: "yyyy/MM/dd hh:mm:ss tt",
                    m: "d MMMM",
                    M: "d MMMM",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "hh:mm tt",
                    T: "hh:mm:ss tt",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "MMMM, yyyy",
                    Y: "MMMM, yyyy"
                },
                "/": "/",
                ":": ":",
                firstDay: 0
            }
        }
    }
})(this);
}));