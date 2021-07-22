
Info = function (message) {
    alert(message);
}

SendToNet = function (dotNetObject)
{
    dotNetObject.invokeMethodAsync('AjouterInfo', "Info from js");
}