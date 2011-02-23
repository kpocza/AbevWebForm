/* variables */
/* field calculations */
/* field check functions */
function CID2() {
  return w_GetRealZero(w_opNot(w_Field("0E0001B001H")));
}
function FldAlertCID2(fid, single) {
    if(!CID2()) {
      showErr(fid, "A mező kitöltése nem lehetséges. (Hibakód=<4/>)", single);
    }
}
function CID3() {
  return w_GetRealZero(w_IsFilled(w_Field("0D0001B001A")));
}
function FldAlertCID3(fid, single) {
    if(!CID3()) {
      showErr(fid, "A mező kitöltése kötelező! (Hibakód=<5/>)", single);
    }
}
function CID4() {
  return w_GetRealZero(w_IsFilled(w_Field("0D0001B002A")));
}
function FldAlertCID4(fid, single) {
    if(!CID4()) {
      showErr(fid, "A mező kitöltése kötelező! (Hibakód=<6/>)", single);
    }
}
function CID5() {
  return w_GetRealZero(w_Imp(w_opOr(w_IsFilled(w_Field("0K0001C001A")),w_IsFilled(w_Field("0K0001C002A"))),w_IsFilled(w_Field("0K0001C003A"),w_Field("0K0001C004A"),w_Field("0K0001C005A"),w_Field("0K0001C006A"),w_Field("0K0001C008A"),w_Field("0K0001C009A"),w_Field("0K0001C011A"),w_Field("0K0001C012A"),w_Field("0K0001C014A"),w_Field("0K0001C016A"))));
}
function FldAlertCID5(fid, single) {
    if(!CID5()) {
      showErr(fid, "Amennyiben megadja a folytatás jogcímét, valamennyi adat #13megadása kötelező. (Hibakód=<19/>)", single);
    }
}
function CID6() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0C0001E002A")),w_IsFilled(w_Field("0C0001E003A"),w_Field("0C0001E005A"),w_Field("0C0001E006A"),w_Field("0C0001E008A"),w_Field("0C0001E009A"),w_Field("0C0001E011A"),w_Field("0C0001E013A"),w_Field("0C0001E014A"),w_Field("0C0001E015A"),w_Field("0C0001E017A"),w_Field("0C0001E019A"),w_Field("0C0001E021A"),w_Field("0C0001E022A"),w_Field("0C0001E028A"))));
}
function FldAlertCID6(fid, single) {
    if(!CID6()) {
      showErr(fid, "A kézbesítési megbízottra vonatkozó valamennyi adat #13megadása kötelező. (Hibakód=<14/>)", single);
    }
}
function CID7() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0IXXXXC001A")),w_IsFilled(w_Field("0IXXXXC003A"),w_Field("0IXXXXC005A"),w_Field("0IXXXXC007A"),w_Field("0IXXXXC008A"))));
}
function FldAlertCID7(fid, single) {
    if(!CID7()) {
      showErr(fid, "Telephely/fióktelep megadása esetén a #13telephelyre/fióktelepre vonatkozó valamennyi adat kitöltése #13kötelező. (Hibakód=<15/>)", single);
    }
}
function CID8() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0IXXXXC013A")),w_IsFilled(w_Field("0IXXXXC015A"),w_Field("0IXXXXC017A"),w_Field("0IXXXXC019A"),w_Field("0IXXXXC020A"))));
}
function FldAlertCID8(fid, single) {
    if(!CID8()) {
      showErr(fid, "Telephely/fióktelep megadása esetén, a #13telephelyre/fióktelepre vonatkozó valamennyi adat megadása #13kötelező. (Hibakód=<16/>)", single);
    }
}
function CID9() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0IXXXXC025A")),w_IsFilled(w_Field("0IXXXXC027A"),w_Field("0IXXXXC029A"),w_Field("0IXXXXC031A"),w_Field("0IXXXXC032A"))));
}
function FldAlertCID9(fid, single) {
    if(!CID9()) {
      showErr(fid, "Telephely/fióktelep megadása esetén, a #13telephelyre/fióktelepre vonatkozó valamennyi adat megadása #13kötelező. (Hibakód=<17/>)", single);
    }
}
function CID10() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0IXXXXC037A")),w_IsFilled(w_Field("0IXXXXC039A"),w_Field("0IXXXXC041A"),w_Field("0IXXXXC043A"),w_Field("0IXXXXC044A"))));
}
function FldAlertCID10(fid, single) {
    if(!CID10()) {
      showErr(fid, "Telephely/fióktelep megadása esetén, a #13telephelyre/fióktelepre vonatkozó valamennyi adat megadása #13kötelező. (Hibakód=<18/>)", single);
    }
}
function CID11() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0K0001C001A")),w_opIsEq(w_FilledCount(w_Field("0K0001C021A"),w_Field("0K0001C022A"),w_Field("0K0001C025A"),w_Field("0K0001C026A"),w_Field("0K0001C027A"),w_Field("0K0001C029A"),w_Field("0K0001C030A"),w_Field("0K0001C031A"),w_Field("0K0001C032A"),w_Field("0K0001C033A"),w_Field("0K0001C034A"),w_Field("0K0001C035A"),w_Field("0K0001C036A"),w_Field("0K0001C037A")),0)));
}
function FldAlertCID11(fid, single) {
    if(!CID11()) {
      showErr(fid, "Amennyiben a folytatás jogcímeként \"Özvegyet\" #13jelölt meg, a 7. pont kitöltése nem lehetséges. #13(Hibakód=<26/>)", single);
    }
}
function CID12() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0K0001C022A")),w_IsFilled(w_Field("0K0001C023A"),w_Field("0K0001C025A"),w_Field("0K0001C027A"),w_Field("0K0001C029A"),w_Field("0K0001C031A"),w_Field("0K0001C032A"),w_Field("0K0001C033A"),w_Field("0K0001C037A"))));
}
function FldAlertCID12(fid, single) {
    if(!CID12()) {
      showErr(fid, "Valamennyi adat megadása kötelező.  (Hibakód=<29/>)", single);
    }
}
function CID13() {
  return w_GetRealZero(w_Imp(w_IsFilled(w_Field("0K0001C001A")),w_opNot(w_IsFilled(w_Field("0K0001C002A")))));
}
function FldAlertCID13(fid, single) {
    if(!CID13()) {
      showErr(fid, "A folytatás jogcímeként vagy az \"Özvegy\" vagy az #13\"Örökös\" adatmező kitöltése lehetséges, mindkettő #13egyszerre nem jelölhető meg. (Hibakód=<30/>)", single);
    }
}
function CID14() {
  return w_IsFilled(w_Field("0A0001D002A"));
}
function FldAlertCID14(fid, single) {
    if(!CID14()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID15() {
  return w_IsFilled(w_Field("0A0001D003A"));
}
function FldAlertCID15(fid, single) {
    if(!CID15()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID16() {
  return w_IsFilled(w_Field("0A0001D008A"));
}
function FldAlertCID16(fid, single) {
    if(!CID16()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID17() {
  return w_IsFilled(w_Field("0A0001D009A"));
}
function FldAlertCID17(fid, single) {
    if(!CID17()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID18() {
  return w_IsFilled(w_Field("0A0001D011A"));
}
function FldAlertCID18(fid, single) {
    if(!CID18()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID19() {
  return w_IsFilled(w_Field("0A0001D014A"));
}
function FldAlertCID19(fid, single) {
    if(!CID19()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID20() {
  return w_IsFilled(w_Field("0A0001D016A"));
}
function FldAlertCID20(fid, single) {
    if(!CID20()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID21() {
  return w_IsFilled(w_Field("0A0001D023A"));
}
function FldAlertCID21(fid, single) {
    if(!CID21()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID22() {
  return w_IsFilled(w_Field("0A0001D019A"));
}
function FldAlertCID22(fid, single) {
    if(!CID22()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID23() {
  return w_IsFilled(w_Field("0A0001D021A"));
}
function FldAlertCID23(fid, single) {
    if(!CID23()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID24() {
  return w_IsFilled(w_Field("0A0001D024A"));
}
function FldAlertCID24(fid, single) {
    if(!CID24()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID25() {
  return w_IsFilled(w_Field("0D0001B004A"));
}
function FldAlertCID25(fid, single) {
    if(!CID25()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID26() {
  return w_IsFilled(w_Field("0B0001D001A"));
}
function FldAlertCID26(fid, single) {
    if(!CID26()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID27() {
  return w_IsFilled(w_Field("0B0001D002A"));
}
function FldAlertCID27(fid, single) {
    if(!CID27()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID28() {
  return w_IsFilled(w_Field("0B0001D004A"));
}
function FldAlertCID28(fid, single) {
    if(!CID28()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID29() {
  return w_IsFilled(w_Field("0B0001D006A"));
}
function FldAlertCID29(fid, single) {
    if(!CID29()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID30() {
  return w_IsFilled(w_Field("0D0001B003A"));
}
function FldAlertCID30(fid, single) {
    if(!CID30()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID31() {
  return w_IsFilled(w_Field("0B0001D011A"));
}
function FldAlertCID31(fid, single) {
    if(!CID31()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID32() {
  return w_IsFilled(w_Field("0A0001D015A"));
}
function FldAlertCID32(fid, single) {
    if(!CID32()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID33() {
  return w_IsFilled(w_Field("0D0001B001A"));
}
function FldAlertCID33(fid, single) {
    if(!CID33()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID34() {
  return w_IsFilled(w_Field("0A0001D017A"));
}
function FldAlertCID34(fid, single) {
    if(!CID34()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID35() {
  return w_IsFilled(w_Field("0C0001D007A"));
}
function FldAlertCID35(fid, single) {
    if(!CID35()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID36() {
  return w_IsFilled(w_Field("0C0001D003A"));
}
function FldAlertCID36(fid, single) {
    if(!CID36()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID37() {
  return w_IsFilled(w_Field("0C0001D005A"));
}
function FldAlertCID37(fid, single) {
    if(!CID37()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID38() {
  return w_IsFilled(w_Field("0C0001D008A"));
}
function FldAlertCID38(fid, single) {
    if(!CID38()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID39() {
  return w_IsFilled(w_Field("0C0001D001A"));
}
function FldAlertCID39(fid, single) {
    if(!CID39()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID40() {
  return w_IsFilled(w_Field("0D0001B002A"));
}
function FldAlertCID40(fid, single) {
    if(!CID40()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
function CID41() {
  return w_IsFilled(w_Field("0GXXXXB012A"));
}
function FldAlertCID41(fid, single) {
    if(!CID41()) {
      showErr(fid, "A mező kötelezően kitöltendő! (Hibakód=<m001>)", single);
    }
}
/* page check functions */
/* form check functions */
/* page visibility calculation functions */
function pageCalc(){
  pgI[1] = true;
  pgI[5] = true;
  pgI[9] = true;
  pgI[2] = true;
  pgI[8] = true;
  pgI[7] = true;
  pgI[0] = true;
  pgI[4] = true;
  pgI[6] = true;
  pgI[3] = true;
  pgI[11] = true;
}
/* form fields relation check function */
function formCheck(){
    clearErr();
    FldAlertCID2("0E0001B001H", false);
    FldAlertCID3("0D0001B001A", false);
    FldAlertCID4("0D0001B002A", false);
    FldAlertCID5("0K0001C001A", false);
    FldAlertCID6("0C0001E002A", false);
    FldAlertCID7("0IXXXXC001A", false);
    FldAlertCID8("0IXXXXC013A", false);
    FldAlertCID9("0IXXXXC025A", false);
    FldAlertCID10("0IXXXXC037A", false);
    FldAlertCID11("0K0001C022A", false);
    FldAlertCID12("0K0001C023A", false);
    FldAlertCID13("0K0001C002A", false);
    FldAlertCID14("0A0001D002A", false);
    FldAlertCID15("0A0001D003A", false);
    FldAlertCID16("0A0001D008A", false);
    FldAlertCID17("0A0001D009A", false);
    FldAlertCID18("0A0001D011A", false);
    FldAlertCID19("0A0001D014A", false);
    FldAlertCID20("0A0001D016A", false);
    FldAlertCID21("0A0001D023A", false);
    FldAlertCID22("0A0001D019A", false);
    FldAlertCID23("0A0001D021A", false);
    FldAlertCID24("0A0001D024A", false);
    FldAlertCID25("0D0001B004A", false);
    FldAlertCID26("0B0001D001A", false);
    FldAlertCID27("0B0001D002A", false);
    FldAlertCID28("0B0001D004A", false);
    FldAlertCID29("0B0001D006A", false);
    FldAlertCID30("0D0001B003A", false);
    FldAlertCID31("0B0001D011A", false);
    FldAlertCID32("0A0001D015A", false);
    FldAlertCID33("0D0001B001A", false);
    FldAlertCID34("0A0001D017A", false);
    FldAlertCID35("0C0001D007A", false);
    FldAlertCID36("0C0001D003A", false);
    FldAlertCID37("0C0001D005A", false);
    FldAlertCID38("0C0001D008A", false);
    FldAlertCID39("0C0001D001A", false);
    FldAlertCID40("0D0001B002A", false);
    FldAlertCID41("0GXXXXB012A", false);
    showErrorDlg();
}
function attachCalculators() {
/* field calculation functions */
/* field check functions */
  $('#0E0001B001H').change(function() {
    FldAlertCID2("0E0001B001H", true);
  });
  $('#0D0001B001A').change(function() {
    FldAlertCID3("0D0001B001A", true);
  });
  $('#0D0001B002A').change(function() {
    FldAlertCID4("0D0001B002A", true);
  });
  $('#0K0001C001A').change(function() {
    FldAlertCID5("0K0001C001A", true);
  });
  $('#0C0001E002A').change(function() {
    FldAlertCID6("0C0001E002A", true);
  });
  $('#0IXXXXC001A').change(function() {
    FldAlertCID7("0IXXXXC001A", true);
  });
  $('#0IXXXXC013A').change(function() {
    FldAlertCID8("0IXXXXC013A", true);
  });
  $('#0IXXXXC025A').change(function() {
    FldAlertCID9("0IXXXXC025A", true);
  });
  $('#0IXXXXC037A').change(function() {
    FldAlertCID10("0IXXXXC037A", true);
  });
  $('#0K0001C022A').change(function() {
    FldAlertCID11("0K0001C022A", true);
  });
  $('#0K0001C023A').change(function() {
    FldAlertCID12("0K0001C023A", true);
  });
  $('#0K0001C002A').change(function() {
    FldAlertCID13("0K0001C002A", true);
  });
  $('#0A0001D002A').change(function() {
    FldAlertCID14("0A0001D002A", true);
  });
  $('#0A0001D003A').change(function() {
    FldAlertCID15("0A0001D003A", true);
  });
  $('#0A0001D008A').change(function() {
    FldAlertCID16("0A0001D008A", true);
  });
  $('#0A0001D009A').change(function() {
    FldAlertCID17("0A0001D009A", true);
  });
  $('#0A0001D011A').change(function() {
    FldAlertCID18("0A0001D011A", true);
  });
  $('#0A0001D014A').change(function() {
    FldAlertCID19("0A0001D014A", true);
  });
  $('#0A0001D016A').change(function() {
    FldAlertCID20("0A0001D016A", true);
  });
  $('#0A0001D023A').change(function() {
    FldAlertCID21("0A0001D023A", true);
  });
  $('#0A0001D019A').change(function() {
    FldAlertCID22("0A0001D019A", true);
  });
  $('#0A0001D021A').change(function() {
    FldAlertCID23("0A0001D021A", true);
  });
  $('#0A0001D024A').change(function() {
    FldAlertCID24("0A0001D024A", true);
  });
  $('#0D0001B004A').change(function() {
    FldAlertCID25("0D0001B004A", true);
  });
  $('#0B0001D001A').change(function() {
    FldAlertCID26("0B0001D001A", true);
  });
  $('#0B0001D002A').change(function() {
    FldAlertCID27("0B0001D002A", true);
  });
  $('#0B0001D004A').change(function() {
    FldAlertCID28("0B0001D004A", true);
  });
  $('#0B0001D006A').change(function() {
    FldAlertCID29("0B0001D006A", true);
  });
  $('#0D0001B003A').change(function() {
    FldAlertCID30("0D0001B003A", true);
  });
  $('#0B0001D011A').change(function() {
    FldAlertCID31("0B0001D011A", true);
  });
  $('#0A0001D015A').change(function() {
    FldAlertCID32("0A0001D015A", true);
  });
  $('#0D0001B001A').change(function() {
    FldAlertCID33("0D0001B001A", true);
  });
  $('#0A0001D017A').change(function() {
    FldAlertCID34("0A0001D017A", true);
  });
  $('#0C0001D007A').change(function() {
    FldAlertCID35("0C0001D007A", true);
  });
  $('#0C0001D003A').change(function() {
    FldAlertCID36("0C0001D003A", true);
  });
  $('#0C0001D005A').change(function() {
    FldAlertCID37("0C0001D005A", true);
  });
  $('#0C0001D008A').change(function() {
    FldAlertCID38("0C0001D008A", true);
  });
  $('#0C0001D001A').change(function() {
    FldAlertCID39("0C0001D001A", true);
  });
  $('#0D0001B002A').change(function() {
    FldAlertCID40("0D0001B002A", true);
  });
  $('#0GXXXXB012A').change(function() {
    FldAlertCID41("0GXXXXB012A", true);
  });
/* page check functions */
};
