$(function () {
    //tbInit();
    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    //var oButtonInit = new ButtonInit();
    //oButtonInit.Init();


});

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        //在初始化table之前，要将table销毁，否则会保留上次加载的内容
        $("#table").bootstrapTable('destroy');
        $('#table').bootstrapTable({
            url: '/User/Query',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            //showColumns: true,                  //是否显示所有的列
            //showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "Id",                     //每一行的唯一标识，一般为主键列
            //showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                checkbox: true
            }, {
                field: 'id',
                title: '序号',
                align: 'center'
            }, {
                field: 'userName',
                title: '用户名',
                align: 'center'
            }, {
                field: 'name',
                title: '姓名',
                align: 'center'
            }, {
                field: 'addTime',
                title: '添加时间',
                align: 'center',
                formatter: function (value, row, index) {
                    var crtTime = new Date(value);
                    return top.dateFtt("yyyy-MM-dd hh:mm:ss", crtTime);//直接调用公共JS里面的时间类处理的办法  
                }
            }, {
                field: 'isDisabled',
                title: '是否启用',
                align: 'center',
                formatter: function (value, row, index) {
                    if (value == true) {
                        return "已启用";
                    } else {
                        return "未启用";
                    }
                }
            }, {
                field: 'operate',
                title: '操作',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: oTableInit.operateFormatter,
                events: operateEvents
            }]
        });
    };

    oTableInit.operateFormatter = function () {
        return [
            ' <a class="edit ml10" href="javascript:void(0)" title="编辑">',
            '<i class="glyphicon glyphicon-edit"></i>',
            '</a>',
            ' <a class="remove ml10" href="javascript:void(0)" title="删除">',
            '<i class="glyphicon glyphicon-remove"></i>',
            '</a>'
        ].join('');
    };

    window.operateEvents = {
        'click .edit': function (e, value, row, index) {
            alert('You click edit icon, row: ' + JSON.stringify(row));
            console.log(value, row, index);
        },
        'click .remove': function (e, value, row, index) {
            alert('You click remove icon, row: ' + JSON.stringify(row));
            console.log(value, row, index);
        }
    };
    return oTableInit;
}


