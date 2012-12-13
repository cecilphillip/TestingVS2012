; (function (window, app, ko, undefined) {
    var eventList = new app.vm.EventsList();
    eventList.loadEvents();
    ko.applyBindings(eventList);

}(window, window.app, ko));