var cleanSelection = function ()
{
    $(this).prop('checked', false);
}

var onClick = function () {

    var checked = $(this).is(":checked");
    
    // Clean all checkboxes
    $("input:checkbox.folder").each(cleanSelection)

    $(this).prop('checked', checked);

    if (checked) {
        var parent = $(this).parent();
        var children = parent.children();
        var parentId = children.filter(".folderId")[0].value;

        $("#ParentFolderId").val(parentId);
    }
    else {
        $("#ParentFolderId").val(null);
    }
};

$("input[type=checkbox]").on("click", onClick);