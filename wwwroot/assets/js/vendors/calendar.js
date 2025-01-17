document.addEventListener("DOMContentLoaded", function () {
  var t = moment().startOf("day"),
    e = t.format("YYYY-MM"),
    n =
      (t.clone().subtract(1, "day").format("YYYY-MM-DD"),
      t.format("YYYY-MM-DD")),
    t =
      (t.clone().add(1, "day").format("YYYY-MM-DD"),
      document.getElementById("calendar"));
  new FullCalendar.Calendar(t, {
    headerToolbar: {
      left: "prev,next today",
      center: "title",
      right: "dayGridMonth,timeGridWeek,timeGridDay,listMonth",
    },
    height: 900,
    contentHeight: 800,
    aspectRatio: 3,
    nowIndicator: !0,
    now: n + "T09:25:00",
    initialView: "dayGridMonth",
    initialDate: n,
    editable: !0,
    dayMaxEvents: !0,
    navLinks: !0,
    events: [
      {
        title: "All Day Event",
        start: e + "-01",
        description: "Toto lorem ipsum dolor sit incid idunt ut",
      },
      {
        title: "Reporting",
        start: e + "-14T13:30:00",
        description: "Lorem ipsum dolor incid idunt ut labore",
        end: e + "-14",
      },
    ],
  }).render();
});
