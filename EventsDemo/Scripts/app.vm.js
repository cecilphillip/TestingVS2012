; (function(window, app, dataservice, $, ko, undefined) {
    app.vm = (function() {

        var EventsList = function() {
            var self = this;
            self.events = ko.observableArray([]);

            self.loadEvents = function() {
                dataservice.getEventListings(bindEvents);
            };
            self.loadUpcomingEvents = function() {
                dataservice.getUpcomingEventListings(bindEvents);
            };
            self.loadPastEvents = function() {
                dataservice.getPastEventListings(bindEvents);
            };
            self.searchEvents = function() {
                var searchTerm = $('#searchbox').val();
                dataservice.searchEventListings(searchTerm, bindEvents);
            };
            self.formatDate = function(eventDateString) {
                var eventDate = new Date(eventDateString);
                var eventHour = (eventDate.getUTCHours() <= 12) ? eventDate.getUTCHours() : eventDate.getUTCHours() - 12;
                return "Date: " + eventDate.getMonth() + "/" + eventDate.getDate() + "/" + eventDate.getFullYear() + " " + eventHour + ":" + eventDate.getMinutes();
            }
            function bindEvents(data) {
                self.events(data);
            }
        };

        return {
            EventsList: EventsList
        };
    }());

}(window, window.app = window.app || {}, window.app.dataservice, jQuery, ko));