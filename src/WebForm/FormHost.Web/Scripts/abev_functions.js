/* abev function is js */
//fldType, 1=text,2=bool,3=date,4=number,5=nil
var TEXT = 1;
var BOOL = 2;
var DATE = 3;
var NUM = 4;
var NIL = 5;

var fldI = new Array();
var pgI = new Array();

function w_Field(fid) {
    var t = fldI[fid].T;
    if (t == BOOL) {
        return { val: $('#' + fid).is(':checked'), type: BOOL };
    }
    var fld = {
        val: $('#' + fid).val(),
        type: t
    };
    return fld;
}
function w_NIL() {
    return { val: null, type: NIL };
}

function w_GetRealZero(ap) {
    var a = tocmplx(ap);
    return a.val;
}
function w_Round(ap) {
    var a = tocmplx(ap);
    if (a.type == NUM) {
        return {val: Math.round(a.val), type: NUM};
    }
    return a;
}
function w_opAdd(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) + hlpAsInt(b.val), type: NUM };
    }
    return null;
}
function w_opSub(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) - hlpAsInt(b.val), type: NUM };
    }
    if (a.type == DATE && b.type == DATE) {
        return { val: hlpDAsInt(a.val) - hlpDAsInt(b.val), type: NUM };
    }
    return null;
}
function w_opMul(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) * hlpAsInt(b.val), type: NUM };
    }
    return null;
}
function w_opDiv(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) / hlpAsInt(b.val), type: NUM };
    }
    return null;
}
function w_opMod(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) % hlpAsInt(b.val), type: NUM };
    }
    return null;
}
function w_opIsEq(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NIL) {
        return { val: b.type == NIL || b.val == null || b.val == "", type: BOOL };
    }
    if (b.type == NIL) {
        return { val: a.type == NIL || a.val == null || a.val == "", type: BOOL };
    }
    if (a.type == NUM && b.type == NUM) {
        return { val: hlpAsInt(a.val) == hlpAsInt(b.val), type: BOOL };
    }
    return { val: a.val == b.val, type: BOOL };
}
function w_opIsNe(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    return w_opNot(w_opIsEq(a, b));
}
function w_opIsLt(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == NUM && b.type == NUM) {
        var i1 = hlpAsInt(a.val);
        var i2 = hlpAsInt(b.val);
        return { val: i1 < i2, type: BOOL };
    }
    if (a.type == DATE && b.type == DATE) {
        var i1 = hlpDAsInt(a.val);
        var i2 = hlpDAsInt(b.val);
        return { val: i1 < i2, type: BOOL };
    }
    return { val: a.val < b.val, type: BOOL };
}

function w_opIsGt(ap, bp) {
    return w_opIsLt(bp, ap);
}
function w_opIsLe(ap, bp) {
    return w_opNot(w_opIsGt(ap, bp));
}
function w_opIsGe(ap, bp) {
    return w_opNot(w_opIsLt(ap, bp));
}
function w_opAnd(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    return { val: a.val && b.val, type: BOOL };
}
function w_opOr(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    return { val: a.val || b.val, type: BOOL };
}
function w_opNot(ap) {
    var a = tocmplx(ap);
    return { val: !a.val, type: BOOL };
}
function w_Abs(ap) {
    var a = tocmplx(ap);
    return { val: Math.abs(hlpAsInt(a.val)), type: NUM };
}
function w_Ekv(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == BOOL && b.type == BOOL) {
        return { val: a.val == b.val, type: BOOL };
    }
    return null;
}
function w_Imp(ap, bp) {
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    if (a.type == BOOL && b.type == BOOL) {
        return { val: !(a.val == true && b.val == false), type: BOOL };
    }
    return null;
}

function w_SubStr(ap, fp, lp) {
    var a = tocmplx(ap);
    var f = tocmplx(fp);
    var l = tocmplx(lp);
    return { val: a.val.substring(f.val - 1, f.val + l.val - 1), type: TEXT };
}
function w_Len(ap) {
    var a = tocmplx(ap);
    return { val: a.val == null ? 0 : a.val.length, type: NUM };
}
function w_if(condp, ap, bp) {
    var cond = tocmplx(condp);
    var a = tocmplx(ap);
    var b = tocmplx(bp);
    return cond.val == true ? a : b;
}
function w_Min() {
    var args = w_Min.arguments;
    var min = tocmplx(args[0]);
    for (i = 1; i < args.length; i++) {
        var a = tocmplx(args[i]);
        if (w_opIsLt(a, min)) {
            min = a;
        }
    }
    return min;
}
function w_Max() {
    var args = w_Max.arguments;
    var max = tocmplx(args[0]);
    for (i = 1; i < args.length; i++) {
        var a = tocmplx(args[i]);
        if (w_opIsGt(a, max)) {
            max = a;
        }
    }
    return max;
}
function w_Sum() {
    var sum = { val: 0, type: NUM };
    var args = w_Sum.arguments;
    for (i = 1; i < args.length; i++) {
        sum = w_opAdd(sum, tocmplx(args[i]));
    }
    return sum;
}
function w_In() {
    var args = w_In.arguments;
    var chk = tocmplx(args[0]);
    for (i = 1; i < args.length; i++) {
        var a = tocmplx(args[i]);
        if (w_opIsEq(a, chk)) {
            return { val: true, type: BOOL };
        }
    }
    return { val: false, type: BOOL };
}
function w_IsFilled(ap) {
    var a = tocmplx(ap);
    if (a.type == BOOL) {
        return a.val;
        //return { val: a.val == true, type: BOOL };
    }
    //return { val: a != null && a.val != null && a.val != "", type: BOOL };
    return a != null && a.val != null && a.val != "";
}
function w_FilledCount() {
    var args = w_FilledCount.arguments;
    var cnt = 0; ;
    for (i = 0; i < args.length; i++) {
        if (w_IsFilled(args[0])) {
            cnt++;
        }
    }
    return { val: cnt, type: NUM };
}
function w_IsCorrectDate(ap) {
    var a = tocmplx(ap);
    if (a == null || a.val == null || a.val == "") {
        return { val: true, type: BOOL };
    }
    var str = a.val.toString();
    if (str.match(/^\d{4}\-\d{2}\-\d{2}$/)!= null) {
        var d = Date.parseLocale(str, "yyyy-MM-dd")
        return { val: d != null, type: BOOL };
    }
    if (str.match(/^\d{8}$/)!= null) {
        var d = Date.parseLocale(str, "yyyyMMdd")
        return { val: d != null, type: BOOL };
    }
    return false;
}
function w_IsCorrectTaxNum(ap) {
    var a = tocmplx(ap);
    if (a.type != NUM && a.type != TEXT) {
        return { val: false, type: BOOL };
    }
    if (a.val == null) {
        return { val: false, type: BOOL };
    }
    var txt = a.val.toString();
    if (txt.length != 11) {
        return { val: false, type: BOOL };
    }
    var n = (10 - (txt[0] * 9 + txt[1] * 7 + txt[2] * 3 + txt[3] * 1 +
            txt[4] * 9 + txt[5] * 7 + txt[6] * 3) % 10) % 10;

    if (n!= txt[7]) {
        return { val: false, type: BOOL };
    }
    if (!(txt[8] >= '1' && txt[8] < '3')) {
        return { val: false, type: BOOL };
    }
    //TODO: utolsó része

    return { val: true, type: BOOL };
}
function w_IsCorrentTaxIdNum(ap) {
    var a = tocmplx(ap);
    if (a.type != NUM && a.type!= TEXT) {
        return { val: false, type: BOOL };
    }
    if (a.val == null) {
        return { val: false, type: BOOL };
    }
    var txt = a.val.toString();
    if (txt.length != 10) {
        return { val: false, type: BOOL };
    }
    var n = 0;
    for (var i = 0; i < 9; i++) {
        n += (i + 1) * parseInt(txt[i]);
    }
    var nl = n % 11;
    if (nl == 10) nl = 0;

    return { val: nl == parseInt(txt[9]) && txt[0] == '8', type: BOOL };
}
function w_DateDay(dp) {
    var d = tocmplx(dp);
    return { val: d.val % 100, type: NUM };
}
function w_DateMonth(dp) {
    var d = tocmplx(dp);
    return { val: (d.val / 100) % 100, type: NUM };
}

function hlpAsInt(val) {
    var ret = parseInt(val);
    if (isNaN(ret))
        return null;
    return ret;
}
function hlpDAsInt(val) {
    var ret = parseInt(val.replace(/-/g, ""));
    if (isNaN(ret))
        return null;
    return ret;
}
function tocmplx(ap) {
    if (ap == null) {
        return { val: null, type: NUM };
    }

    var tofv = typeof (ap.val);
    var toft = typeof (ap.type);

    if (tofv == "undefined" || toft == "undefined") {
        if (typeof (ap) == "number") {
            return { val: ap, type: NUM };
        }
        if (typeof (ap) == "boolean") {
            return { val: ap, type: BOOL };
        }
        return { val: ap.toString(), type: TEXT };
    }
    return ap;
}

function showErr(fid, msg, single) {
    if (fid != null) {
        if (pgI[fldI[fid].P] == true) {
            addErr(fid + ' ' + msg);
        }
    }
    else {
        addErr(msg);
    }

    if (single) {
        showErrorDlg();
    }
}

function clearErr() {
    $('#errors').html('');
}
function addErr(str) {
    $('#errors').html($('#errors').html() + '<br />' + str);
}
function showErrorDlg() {
    $('#errors').dialog({ width: 800, modal: true, close: function (event, ui) { clearErr(); } });
}
function initSingleField(fid, val) {
    var t = fldI[fid].T;
    var f = $('#' + fid);

    if (t == TEXT) {
        f.val(val);
    }
    else if (t == BOOL) {
        if (val == 'on') {
            f.attr('checked', true);
        }
    }
    else if (t == DATE) {
        f.val(val);
    }
    else if (t == NUM) {
        f.val(val);
    }
}