"use strict";
function elementExists(e) {
  return null !== document.querySelector(e);
}
var courseForm, stepperForm;
elementExists("#courseForm") &&
  document.addEventListener("DOMContentLoaded", function () {
    courseForm = new Stepper(document.querySelector("#courseForm"), {
      linear: !1,
      animation: !0,
    });
  }),
  elementExists("#stepperForm") &&
    document.addEventListener("DOMContentLoaded", function () {
      stepperForm = new Stepper(document.querySelector("#stepperForm"), {
        linear: !1,
        animation: !0,
      });
    });
