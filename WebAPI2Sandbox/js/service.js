var service = (function($){
	return {
		Request: function(method, url, dataType, contentType, data){
			return $.ajax({
				method: method,
				url: url,
				dataType: dataType,
				contentType: contentType,
				data: data
			});
		}
	};
})(jQuery);




$(function(){

	function MakeRequest()
	{
		$("#output").html("Making request...");	

		service.Request(
			$("#method").val(),
			$("#url").val(),
			$("#dataType").val(),
			$("#contentType").val(),
			$("#data").val()
		).fail(function(){
			$("#output").html("Request failed.");
		}).done(function(data){
			data = data || "Did not receive response.";
			$("#output").html(JSON.stringify(data));
		});
	}


	$("input").on({
		keydown: function(e){
			if (e.which == 13)
			{
				MakeRequest();
			}
		}
	});
});
