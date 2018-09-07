
function $(id)
{
	return document.getElementById(id);
}

$.baseUrl = function() {
	return window.location.href.match(/^.*\//)[0];
}

$.ajax = function(url, settings)
{
	settings = settings || {};
	var method = settings.method || 'GET';
	var async = settings.async || true;
	var complete = settings.complete || function() {};

	var req = new XMLHttpRequest();
	req.open(method, url, async);
	req.onreadystatechange = function() {
		if (req.readyState === 4) {
			complete(req.responseText, req.status)
		}
	}
	return req.send(settings.data);
}

$.get = function(url, callback)
{
	return $.ajax(url, {
		method: 'GET',
		complete: callback
	});
}

$.put = function(url, data, callback)
{
	if (typeof(data) === 'function') {
		callback = callback || data;
		data = null;
	}

	return $.ajax(url, {
		method: 'PUT',
		complete: callback,
		data: data
	});
}

$.post = function (url, data, callback) {
	if (typeof (data) === 'function') {
		callback = callback || data;
		data = null;
	}

	return $.ajax(url, {
		method: 'POST',
		complete: callback,
		data: data
	});
}
