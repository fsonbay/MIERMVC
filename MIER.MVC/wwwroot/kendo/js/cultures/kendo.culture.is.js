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
    kendo.cultures["is"] = {
        name: "is",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ".",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "",
                abbr: "",
                pattern: ["-n $","n $"],
                decimals: 0,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "kr"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["sunnudagur","m??nudagur","??ri??judagur","mi??vikudagur","fimmtudagur","f??studagur","laugardagur"],
                    namesAbbr: ["sun.","m??n.","??ri.","mi??.","fim.","f??s.","lau."],
                    namesShort: ["su.","m??.","??r.","mi.","fi.","f??.","la."]
                },
                months: {
                    names: ["jan??ar","febr??ar","mars","apr??l","ma??","j??n??","j??l??","??g??st","september","okt??ber","n??vember","desember"],
                    namesAbbr: ["jan.","feb.","mar.","apr.","ma??","j??n.","j??l.","??g??.","sep.","okt.","n??v.","des."]
                },
                AM: ["f.h.","f.h.","F.H."],
                PM: ["e.h.","e.h.","E.H."],
                patterns: {
                    d: "d.M.yyyy",
                    D: "dddd, d. MMMM yyyy",
                    F: "dddd, d. MMMM yyyy HH:mm:ss",
                    g: "d.M.yyyy HH:mm",
                    G: "d.M.yyyy HH:mm:ss",
                    m: "d. MMMM",
                    M: "d. MMMM",
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