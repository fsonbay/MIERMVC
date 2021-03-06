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
    kendo.cultures["nnh-CM"] = {
        name: "nnh-CM",
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
                name: "Central African CFA Franc",
                abbr: "XAF",
                pattern: ["-$ n","$ n"],
                decimals: 0,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "FCFA"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["ly???????? s???????t??","mvf?? ly??????","mb??????nt?? mvf?? ly??????","ts??ts?????? ly??????","mb??????nt?? tsets?????? ly??????","mvf?? m??ga ly??????","m??ga ly??????"],
                    namesAbbr: ["ly???????? s???????t??","mvf?? ly??????","mb??????nt?? mvf?? ly??????","ts??ts?????? ly??????","mb??????nt?? tsets?????? ly??????","mvf?? m??ga ly??????","m??ga ly??????"],
                    namesShort: ["ly???????? s???????t??","mvf?? ly??????","mb??????nt?? mvf?? ly??????","ts??ts?????? ly??????","mb??????nt?? tsets?????? ly??????","mvf?? m??ga ly??????","m??ga ly??????"]
                },
                months: {
                    names: ["sa?? tsets?????? l??m","sa?? k??g ngw????","sa?? lepy?? sh??m","sa?? c????","sa?? ts?????? c????","sa?? nj??ol????","sa?? ty????b ty????b mb??????","sa?? mb??????","sa?? ngw?????? mb????","sa?? t????a tsets????","sa?? mejwo????","sa?? l??m"],
                    namesAbbr: ["sa?? tsets?????? l??m","sa?? k??g ngw????","sa?? lepy?? sh??m","sa?? c????","sa?? ts?????? c????","sa?? nj??ol????","sa?? ty????b ty????b mb??????","sa?? mb??????","sa?? ngw?????? mb????","sa?? t????a tsets????","sa?? mejwo????","sa?? l??m"]
                },
                AM: ["mba????mba??","mba????mba??","MBA????MBA??"],
                PM: ["ncw??nz??m","ncw??nz??m","NCW??NZ??M"],
                patterns: {
                    d: "dd/MM/yyyy",
                    D: "dddd , 'ly??'???? d 'na' MMMM, yyyy",
                    F: "dddd , 'ly??'???? d 'na' MMMM, yyyy HH:mm:ss",
                    g: "dd/MM/yyyy HH:mm",
                    G: "dd/MM/yyyy HH:mm:ss",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": "/",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));