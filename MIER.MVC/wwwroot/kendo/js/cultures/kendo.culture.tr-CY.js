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
    kendo.cultures["tr-CY"] = {
        name: "tr-CY",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ".",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-%n","%n"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Euro",
                abbr: "EUR",
                pattern: ["-$n","$n"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "???"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["Pazar","Pazartesi","Sal??","??ar??amba","Per??embe","Cuma","Cumartesi"],
                    namesAbbr: ["Paz","Pzt","Sal","??ar","Per","Cum","Cmt"],
                    namesShort: ["Pa","Pt","Sa","??a","Pe","Cu","Ct"]
                },
                months: {
                    names: ["Ocak","??ubat","Mart","Nisan","May??s","Haziran","Temmuz","A??ustos","Eyl??l","Ekim","Kas??m","Aral??k"],
                    namesAbbr: ["Oca","??ub","Mar","Nis","May","Haz","Tem","A??u","Eyl","Eki","Kas","Ara"]
                },
                AM: ["????","????","????"],
                PM: ["??S","??s","??S"],
                patterns: {
                    d: "d.MM.yyyy",
                    D: "d MMMM yyyy dddd",
                    F: "d MMMM yyyy dddd h:mm:ss tt",
                    g: "d.MM.yyyy h:mm tt",
                    G: "d.MM.yyyy h:mm:ss tt",
                    m: "d MMMM",
                    M: "d MMMM",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "h:mm tt",
                    T: "h:mm:ss tt",
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