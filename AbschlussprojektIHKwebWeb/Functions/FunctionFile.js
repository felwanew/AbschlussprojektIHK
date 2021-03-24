Office.initialize = function () {
}

// Eine Hilfsfunktion zum Hinzufügen einer Statusmeldung zur Infoleiste.
function statusUpdate(icon, text) {
  Office.context.mailbox.item.notificationMessages.replaceAsync("status", {
    type: "informationalMessage",
    icon: icon,
    message: text,
    persistent: false
  });
}

function defaultStatus(event) {
  statusUpdate("icon16" , "Hello World!");
}