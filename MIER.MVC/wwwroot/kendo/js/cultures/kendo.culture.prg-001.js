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
    kendo.cultures["prg-001"] = {
        name: "prg-001",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": "??",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Special Drawing Rights",
                abbr: "XDR",
                pattern: ["-n $","n $"],
                decimals: 2,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "XDR"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["nad??li","panad??li","wisas??dis","pussisawaiti","ketwirtiks","p??ntniks","sabattika"],
                    namesAbbr: ["nad","pan","wis","pus","ket","p??n","sab"],
                    namesShort: ["nad","pan","wis","pus","ket","p??n","sab"]
                },
                months: {
                    names: ["rags","wassarins","p??lis","sakkis","zallaws","s??menis","l??pa","daggis","sillins","spallins","lapkr??tis","sallaws"],
                    namesAbbr: ["rag","was","p??l","sak","zal","s??m","l??p","dag","sil","spa","lap","sal"]
                },
                AM: ["AM","am","AM"],
                PM: ["PM","pm","PM"],
                patterns: {
                    d: "dd.MM.yyyy",
                    D: "dddd, yyyy 'mettas' d. MMMM",
                    F: "dddd, yyyy 'mettas' d. MMMM HH:mm:ss",
                    g: "dd.MM.yyyy HH:mm",
                    G: "dd.MM.yyyy HH:mm:ss",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": ".",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));