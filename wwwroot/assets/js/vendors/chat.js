!(function () {
  var t = document.querySelectorAll(".contacts-list .contacts-link"),
    c = document.querySelector(".chat-body"),
    e = document.querySelectorAll("[data-close]");
  t.forEach(function (t) {
    t.addEventListener("click", function () {
      c.classList.add("chat-body-visible");
    });
  }),
    e.forEach(function (t) {
      t.addEventListener("click", function (t) {
        t.preventDefault(), c.classList.remove("chat-body-visible");
      });
    });
})();
