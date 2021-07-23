
Info = function (message) {
    alert(message);
}

SendToNet = function ()
{
    Window.dotNetObject.invokeMethodAsync('AjouterInfo', "Info from js");
}