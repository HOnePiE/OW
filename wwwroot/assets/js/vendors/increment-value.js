document.querySelectorAll(".input-group").forEach(function (e) {
  var t = e.querySelector(".button-plus"),
    e = e.querySelector(".button-minus");
  t.addEventListener("click", function (e) {
    var t;
    (e = e).preventDefault(),
      (t = (e = e.target).getAttribute("data-field")),
      (e = e.closest(".input-group").querySelector('input[name="' + t + '"]')),
      (t = parseInt(e.value, 10)),
      isNaN(t) ? (e.value = 0) : (e.value = t + 1);
  }),
    e.addEventListener("click", function (e) {
      var t;
      (e = e).preventDefault(),
        (t = (e = e.target).getAttribute("data-field")),
        (e = e
          .closest(".input-group")
          .querySelector('input[name="' + t + '"]')),
        (t = parseInt(e.value, 10)),
        !isNaN(t) && 0 < t ? (e.value = t - 1) : (e.value = 0);
    });
});
