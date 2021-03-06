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
(function ($, undefined) {
/* Filter menu operator messages */

if (kendo.ui.FilterCell) {
kendo.ui.FilterCell.prototype.options.operators =
$.extend(true, kendo.ui.FilterCell.prototype.options.operators,{
  "date": {
    "eq": "E??it",
    "gt": "Sonra",
    "gte": "Sonra veya e??it",
    "lt": "??nce",
    "lte": "??nce veya e??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "enums": {
    "eq": "E??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "number": {
    "eq": "E??it",
    "gt": "B??y??k",
    "gte": "B??y??k veya e??it",
    "lt": "K??????k",
    "lte": "K??????k veya e??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "string": {
    "contains": "????eriyor",
    "doesnotcontain": "????ermiyor",
    "endswith": "??le biter",
    "eq": "E??it",
    "neq": "E??it de??il",
    "startswith": "??le ba??lar",
    "isnull": "Null",
    "isnotnull": "Null de??il",
    "isempty": "Bo??",
    "isnotempty": "Bo?? de??il",
    "isnullorempty": "De??er i??ermiyor",
    "isnotnullorempty": "De??er i??eriyor"
  }
});
}

/* Filter menu operator messages */

if (kendo.ui.FilterMenu) {
kendo.ui.FilterMenu.prototype.options.operators =
$.extend(true, kendo.ui.FilterMenu.prototype.options.operators,{
  "date": {
    "eq": "E??it",
    "gt": "Sonra",
    "gte": "Sonra veya e??it",
    "lt": "??nce",
    "lte": "??nce veya e??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "enums": {
    "eq": "E??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "number": {
    "eq": "E??it",
    "gt": "B??y??k",
    "gte": "B??y??k veya e??it",
    "lt": "K??????k",
    "lte": "K??????k veya e??it",
    "neq": "E??it de??il",
    "isnull": "Null",
    "isnotnull": "Null de??il"
  },
  "string": {
    "contains": "????eriyor",
    "doesnotcontain": "????ermiyor",
    "endswith": "??le biter",
    "eq": "E??it",
    "neq": "E??it de??il",
    "startswith": "??le ba??lar",
    "isnull": "Null",
    "isnotnull": "Null de??il",
    "isempty": "Bo??",
    "isnotempty": "Bo?? de??il",
    "isnullorempty": "De??er i??eriyor",
    "isnotnullorempty": "De??er i??ermiyor"
  }
});
}

/* ColumnMenu messages */

if (kendo.ui.ColumnMenu) {
kendo.ui.ColumnMenu.prototype.options.messages =
$.extend(true, kendo.ui.ColumnMenu.prototype.options.messages,{
  "columns": "S??tunlar",
  "settings": "S??tun ayarlar??",
  "done": "Tamam",
  "lock": "Kilitle",
  "sortAscending": "Artan S??ralama",
  "sortDescending": "Azalan S??ralama",
  "unlock": "Kilidini A??",
  "filter": "Filtrele"
});
}

/* RecurrenceEditor messages */

if (kendo.ui.RecurrenceEditor) {
kendo.ui.RecurrenceEditor.prototype.options.messages =
$.extend(true, kendo.ui.RecurrenceEditor.prototype.options.messages,{
  "daily": {
    "interval": "G??nler",
    "repeatEvery": "Her g??n tekrarla"
  },
  "end": {
    "after": "Sonra",
    "label": "Biti??",
    "mobileLabel": "Biti??",
    "never": "Asla/Hi??",
    "occurrence": "Olay",
    "on": "Anl??k"
  },
  "frequencies": {
    "daily": "G??nl??k",
    "monthly": "Ayl??k",
    "never": "Asla/Hi??",
    "weekly": "Haftal??k",
    "yearly": "Y??ll??k"
  },
  "monthly": {
    "day": "G??n",
    "interval": "Aylar",
    "repeatEvery": "Her ay tekrarla",
    "repeatOn": "Tekrarla"
  },
  "offsetPositions": {
    "first": "??lk",
    "fourth": "D??rd??nc??",
    "last": "Son",
    "second": "??kinci",
    "third": "??????nc??"
  },
  "weekdays": {
    "day": "G??n",
    "weekday": "???? g??n??",
    "weekend": "Haftasonu"
  },
  "weekly": {
    "interval": "Haftalar",
    "repeatEvery": "Her hafta tekrarla",
    "repeatOn": "Tekrarla"
  },
  "yearly": {
    "interval": "Y??llar",
    "of": "Aras??nda",
    "repeatEvery": "Her Y??l Tekrarla",
    "repeatOn": "Tekrarla"
  }
});
}

/* Editor messages */

if (kendo.ui.Editor) {
kendo.ui.Editor.prototype.options.messages =
$.extend(true, kendo.ui.Editor.prototype.options.messages,{
  "addColumnLeft": "Sola kolon ekle",
  "addColumnRight": "Sa??a kolon ekle",
  "addRowAbove": "Yukar??ya sat??r ekle",
  "addRowBelow": "A??a????ya sat??r ekle",
  "backColor": "Arka plan rengi",
  "bold": "Kal??n ",
  "createLink": "K??pr?? ekleme",
  "createTable": "Tablo olu??tur",
  "deleteColumn": "S??tun silme",
  "deleteFile": "Silmek istedi??inizden emin misiniz?",
  "deleteRow": "Sat??r sil",
  "dialogButtonSeparator": "ya da",
  "dialogCancel": "??ptal",
  "dialogInsert": "Ekle",
  "dialogUpdate": "G??ncelle",
  "directoryNotFound": "Bu isimde bir dizin bulunamad??.",
  "dropFilesHere": "Y??klemek i??in dosyalar?? buraya b??rak??n",
  "emptyFolder": "Bo?? klas??r",
  "fontName": "Font ailesi Se??iniz",
  "fontNameInherit": "Devral??nan Karakter",
  "fontSize": "Font boyutu Se??iniz",
  "fontSizeInherit": "Devral??nan Boyut",
  "foreColor": "Renk",
  "formatBlock": "Bi??im",
  "formatting": "Bi??imlendirme",
  "imageAltText": "Alternatif metin",
  "imageWebAddress": "Web adresi",
  "indent": "Sat??rba????",
  "insertHtml": "HTML ekle",
  "insertImage": "Resim ekle",
  "insertOrderedList": "S??ral?? liste ekle",
  "insertUnorderedList": "S??ras??z liste ekle",
  "invalidFileType": "Se??ilen dosya \"{0}\" ge??erli de??il. Desteklenen dosya t??rleri: {1}.",
  "italic": "??talik karakter",
  "justifyCenter": "Merkezi metin",
  "justifyFull": "Do??rulama",
  "justifyLeft": "Metni sola yasla",
  "justifyRight": "Metni sa??a yasla",
  "linkOpenInNewWindow": "Yeni pencerede a??",
  "linkText": "Metin",
  "linkToolTip": "Ara?? ??pucu",
  "linkWebAddress": "Web adresi",
  "orderBy": "D??zenleme ??l????t??:",
  "orderByName": "??sim",
  "orderBySize": "Boyut",
  "outdent": "????k??nt??",
  "overwriteFile": "Dizinde \"{0}\" isimli bir dosya zaten mevcut. ??zerine yazmak istiyor musunuz?",
  "search": "Arama",
  "strikethrough": "??st?? ??izili",
  "styles": "Stiller",
  "subscript": "??ndis",
  "superscript": "??styaz??",
  "underline": "Alt??n?? ??iz",
  "unlink": "K??pr??y?? Kald??r",
  "uploadFile": "Y??kle",
  "viewHtml": "HTML G??r??n??m?? ",
  "insertFile": "Dosya Ekle"
});
}

/* FilterCell messages */

if (kendo.ui.FilterCell) {
kendo.ui.FilterCell.prototype.options.messages =
$.extend(true, kendo.ui.FilterCell.prototype.options.messages,{
  "clear": "Temizle",
  "filter": "Filtre",
  "isFalse": "Yanl????",
  "isTrue": "Do??ru",
  "operator": "Operat??r"
});
}

/* FilterMenu messages */

if (kendo.ui.FilterMenu) {
kendo.ui.FilterMenu.prototype.options.messages =
$.extend(true, kendo.ui.FilterMenu.prototype.options.messages,{
  "and": "Ve",
  "cancel": "??ptal",
  "clear": "Temizle",
  "filter": "Filtrele",
  "info": "Tan??ma uyan kay??tlar?? g??ster:",
  "title": "Tan??ma uyan kay??tlar?? g??ster",
  "isFalse": "Yanl????",
  "isTrue": "Do??ru",
  "operator": "Operat??r",
  "additionalOperator": "Ek Operat??r",
  "or": "Veya",
  "selectValue": "De??er Se??iniz",
  "value": "De??er",
  "additionalValue": "Ek De??er",
  "logic": "Ba????nt??"
});
}

/* FilterMultiCheck messages */

if (kendo.ui.FilterMultiCheck) {
kendo.ui.FilterMultiCheck.prototype.options.messages =
$.extend(true, kendo.ui.FilterMultiCheck.prototype.options.messages,{
  "search": "Arama",
  "checkAll": "T??m??n?? ????aretle",
  "clear": "Temizle",
  "filter": "Filtrele",
  "selectedItemsFormat": "{0} se??enek i??aretlendi"
});
}

/* Grid messages */

if (kendo.ui.Grid) {
kendo.ui.Grid.prototype.options.messages =
$.extend(true, kendo.ui.Grid.prototype.options.messages,{
  "commands": {
    "canceledit": "??ptal",
    "cancel": "De??i??iklikleri iptal et",
    "create": "Yeni Kay??t Ekle",
    "destroy": "Sil",
    "edit": "D??zenle",
    "excel": "Excel Kaydet",
    "pdf": "PDF Kaydet",
    "save": "De??i??iklikleri Kaydet",
    "select": "Se??",
    "update": "G??ncelle"
  },
  "editable": {
    "cancelDelete": "??ptal",
    "confirmation": "Kay??tlar?? silmek istedi??inizden emin misiniz ?",
    "confirmDelete": "Sil"
  }
});
}

/* Groupable messages */

if (kendo.ui.Groupable) {
kendo.ui.Groupable.prototype.options.messages =
$.extend(true, kendo.ui.Groupable.prototype.options.messages,{
  "empty": "Bir s??tun ba??l??????n?? s??r??kleyin ve bu s??tuna g??re grupland??rmak i??in buraya b??rak??n"
});
}

/* Pager messages */

if (kendo.ui.Pager) {
kendo.ui.Pager.prototype.options.messages =
$.extend(true, kendo.ui.Pager.prototype.options.messages,{
  "allPages": "T??m??",
  "display": "{0} - {1} aral?????? g??steriliyor. Toplam {2} ????e var",
  "empty": "G??r??nt??lenecek ????e yok",
  "first": "??lk sayfaya git",
  "itemsPerPage": "Sayfa ba????na ??r??n",
  "last": "Son sayfaya git",
  "morePages": "Daha fazla sayfa",
  "next": "Bir sonraki sayfaya git",
  "of": "{0}",
  "page": "Sayfa",
  "previous": "Bir ??nceki sayfaya git",
  "refresh": "G??ncelle"
});
}

/* TreeListPager messages */

if (kendo.ui.TreeListPager) {
kendo.ui.TreeListPager.prototype.options.messages =
$.extend(true, kendo.ui.TreeListPager.prototype.options.messages,{
  "allPages": "T??m??",
  "display": "{0} - {1} aral?????? g??steriliyor. Toplam {2} ????e var",
  "empty": "G??r??nt??lenecek ????e yok",
  "first": "??lk sayfaya git",
  "itemsPerPage": "Sayfa ba????na ??r??n",
  "last": "Son sayfaya git",
  "morePages": "Daha fazla sayfa",
  "next": "Bir sonraki sayfaya git",
  "of": "{0}",
  "page": "Sayfa",
  "previous": "Bir ??nceki sayfaya git",
  "refresh": "G??ncelle"
});
}

/* Scheduler messages */

if (kendo.ui.Scheduler) {
kendo.ui.Scheduler.prototype.options.messages =
$.extend(true, kendo.ui.Scheduler.prototype.options.messages,{
  "allDay": "T??m g??n",
  "cancel": "??ptal Et",
  "editable": {
    "confirmation": "Bu etkinli??i silmek istedi??inizden emin misiniz?"
  },
  "date": "Tarih",
  "deleteWindowTitle": "Etkinli??i sil",
  "destroy": "Sil",
  "editor": {
    "allDayEvent": "T??m g??n s??ren olay",
    "description": "Tan??m",
    "editorTitle": "Olay",
    "end": "Biti??",
    "endTimezone": "Biti?? saati",
    "noTimezone": "Zaman Aral?????? belirtilmemi??",
    "repeat": "Tekrar",
    "separateTimezones": "Ayr?? bir ba??lang???? ve biti?? Zaman aral?????? kullan",
    "start": "Ba??lang????",
    "startTimezone": "Ba??lang???? Saati",
    "timezone": "",
    "timezoneEditorButton": "Zaman Aral??????",
    "timezoneEditorTitle": "Zaman Aral??????",
    "title": "Tan??m"
  },
  "event": "Olay",
  "recurrenceMessages": {
    "deleteRecurring": "Sadece bu olay?? m?? yoksa b??t??n seriyi mi silmek istiyorsunuz?",
    "deleteWindowOccurrence": "Ge??erli yinelemeyi Sil",
    "deleteWindowSeries": "Seriyi Sil",
    "deleteWindowTitle": "Tekrarlanan ????eyi Sil",
    "editRecurring": "Sadece bu olay?? m?? yoksa b??t??n seriyi mi d??zenlemek istiyorsunuz?",
    "editWindowOccurrence": "Ge??erli Olay?? D??zenle",
    "editWindowSeries": "Seriyi d??zenle",
    "editWindowTitle": "Tekrarlanan ????eyi D??zenle"
  },
  "save": "Kaydet",
  "showFullDay": "T??m g??n g??ster",
  "showWorkDay": "???? saatlerini g??ster",
  "time": "Zaman",
  "today": "Bug??n",
  "views": {
    "agenda": "G??ndem",
    "day": "G??n",
    "month": "Ay",
    "week": "Hafta",
    "workWeek": "??al????ma Haftas??"
  }
});
}

/* Upload messages */

if (kendo.ui.Upload) {
kendo.ui.Upload.prototype.options.localization =
$.extend(true, kendo.ui.Upload.prototype.options.localization,{
  "cancel": "??ptal Et",
  "dropFilesHere": "Y??klemek i??in dosyalar?? buraya b??rak??n",
  "headerStatusUploaded": "Tamamland??",
  "headerStatusUploading": "Y??kleniyor",
  "remove": "Kald??r",
  "retry": "Tekrar Dene",
  "select": "Se??iniz",
  "statusFailed": "Ba??ar??s??z Oldu",
  "statusUploaded": "Y??klendi",
  "statusUploading": "Y??kleniyor",
  "uploadSelectedFiles": "Se??ilen dosyalar?? Y??kle"
});
}

/* Dialog */

if (kendo.ui.Dialog) {
kendo.ui.Dialog.prototype.options.messages =
$.extend(true, kendo.ui.Dialog.prototype.options.localization, {
  "close": "Kapat"
});
}

/* Alert */

if (kendo.ui.Alert) {
kendo.ui.Alert.prototype.options.messages =
$.extend(true, kendo.ui.Alert.prototype.options.localization, {
  "okText": "Tamam"
});
}

/* Confirm */

if (kendo.ui.Confirm) {
kendo.ui.Confirm.prototype.options.messages =
$.extend(true, kendo.ui.Confirm.prototype.options.localization, {
  "okText": "Tamam",
  "cancel": "??ptal"
});
}

/* Prompt */
if (kendo.ui.Prompt) {
kendo.ui.Prompt.prototype.options.messages =
$.extend(true, kendo.ui.Prompt.prototype.options.localization, {
  "okText": "Tamam",
  "cancel": "??ptal"
});
}

/* DateInput */
if (kendo.ui.DateInput) {
  kendo.ui.DateInput.prototype.options.messages =
    $.extend(true, kendo.ui.DateInput.prototype.options.messages, {
      "year": "y??l",
      "month": "ay",
      "day": "g??n",
      "weekday": "haftan??n g??n??",
      "hour": "saat",
      "minute": "dakika",
      "second": "saniye",
      "dayperiod": "AM/PM"
    });
}  
  
})(window.kendo.jQuery);
}));