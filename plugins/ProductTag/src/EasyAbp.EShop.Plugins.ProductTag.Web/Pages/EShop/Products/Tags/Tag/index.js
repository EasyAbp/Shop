$(function () {

    var l = abp.localization.getResource('Products');

    var service = easyAbp.eShop.products.tags.tag;
    var createModal = new abp.ModalManager(abp.appPath + 'EShop/Products/Tags/Tag/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'EShop/Products/Tags/Tag/EditModal');

    var dataTable = $('#TagTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function () {
            return { storeId: storeId, showHidden: true }
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Product'),
                                action: function (data) {
                                    document.location.href = document.location.origin +
                                        '/EShop/Products/Products/Product?StoreId=' + storeId + '&TagId=' + data.record.id;
                                }
                            },
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('TagDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                        service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "id"},
            //{ data: "storeId" },
            { data: "description" },
            { data: "mediaResources" },
            //{ data: "isHidden" },
            { data: "displayName" },
            //{ data: "code" },
            //{ data: "level" },
            { data: "parentId" },
            //{ data: "parent" },
            //{ data: "children" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTagButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});