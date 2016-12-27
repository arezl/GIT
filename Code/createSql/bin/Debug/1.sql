
alter table   [WX_Activity].[dbo].Activity_Type   add  img_URL    varchar(128)  null default ''
/*==========================================================*/
/*==============================================================*/
/* Table: act_sign_order_record                                 */
/*==============================================================*/
create table act_sign_order_record (
   card_id              varchar(20)          null,
   status               char(2)              null,
   flow_time            datetime             null,
   UseAcc               int                  null,
   SignUpID             int                  null,
   pay_amount           numeric(16,2)         null,
   sale_amount          numeric(16,2)        null constraint DF__t_rm_payf__sale___7F60ED59 default (0),
   flow_no              varchar(14)          not null,
   sign_money           decimal(10,2)        null,
   SignUpNum            int                  null,
   WX_ID                varchar(Max)         null,
   accPay_card_id       varchar(20)          null,
   pay_way              char(3)              collate Chinese_PRC_CI_AS null,
   is_use_acc           char(1)              null,
   WX_flow_no              varchar(60)         null,
   constraint PK_ACT_SIGN_ORDER_RECORD primary key (flow_no)
)


 

 

/*==============================================================*/
/* Table: WxPayDetail                                           */
/*==============================================================*/
create table WxPayDetail (
   WX_ID                varchar(Max)         null,
   flow_no              varchar(14)          null,
   pay_time             datetime             null,
   pay_amount           numeric(16,4)          null,
   third_no             varchar(60)          null,
      WX_flow_no              varchar(60)         null,
   status               char(1)              null,
   id                   int                  identity,
   vgf_branch_no        char(6)              collate Chinese_PRC_CI_AS null,
   memo                 varchar(255)         collate Chinese_PRC_CI_AS null,
   constraint PK_WXPAYDETAIL primary key (id)
)


/*==============================================================*/
/* Table: vip_good_flow                                         */
/*==============================================================*/
 

/*==============================================================*/
/* Table: vip_good_flow                                         */
/*==============================================================*/
create table dbo.vip_good_flow (
   vgf_flowno           numeric(8)           identity(1, 1),
   vgf_branch_no        char(6)              collate Chinese_PRC_CI_AS null,
   vgf_flag             char(1)              collate Chinese_PRC_CI_AS not null  default '1',
   vgf_vip_no           varchar(20)          collate Chinese_PRC_CI_AS null,
   vgf_item_no          varchar(20)          collate Chinese_PRC_CI_AS null,
   vgf_item_num         int                  null,
   vgf_vip_num          numeric(11,2)        null,
   vgf_oper             varchar(10)          collate Chinese_PRC_CI_AS null,
   vgf_date             datetime             null,
   memo                 varchar(255)         collate Chinese_PRC_CI_AS null,
   com_flag             char(1)              collate Chinese_PRC_CI_AS null,
   record_mark          varchar(255)         collate Chinese_PRC_CI_AS null,
   flow_no              varchar(14)          null,
   constraint PK_T_RM_VIP_GOOD_FLOW primary key (vgf_flowno)
         on "PRIMARY"
)
 
 /*==============================================================*/
/* Table: act_sign_pay_flow                                     */
/*==============================================================*/
create table act_sign_pay_flow (
   acc_num              int                  null,
   pay_amount           numeric(16,4)        null,
   id                   int                  identity,
   pay_way              char(3)              collate Chinese_PRC_CI_AS null,
   pay_time             datetime             null,
   memo                 varchar(255)         collate Chinese_PRC_CI_AS null,
   sale_amount          numeric(16,4)        null   default (0),
   card_id              varchar(20)          null,
   flow_no              varchar(14)          null,
   WX_ID                varchar(Max)         null,
   constraint PK_ACT_SIGN_PAY_FLOW primary key (id)
)
 
 

/*==============================================================*/
/* Table: payment_info                                          */
/*==============================================================*/
create table [WX_SYSMGT].[dbo].[payment_info] (
   pay_way              char(3)              collate Chinese_PRC_CI_AS not null,
   pay_flag             char(1)              collate Chinese_PRC_CI_AS not null,
   pay_name             varchar(20)          collate Chinese_PRC_CI_AS not null,
   rate                 numeric(10,4)        null,
   default_amt          numeric(16,4)        null,
   pay_memo             varchar(255)         collate Chinese_PRC_CI_AS null,
   other_flag           varchar(2)           collate Chinese_PRC_CI_AS null,
   constraint PK_PAYMENT_INFO primary key (pay_way, pay_flag)
)
 
/*==============================================================*/
/* Table: vip_num_tempCost                                      */
/*==============================================================*/
CREATE TABLE [WX_VIP].[dbo].[vip_num_tempCost](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[happen_time] [datetime] NULL,
	[vip_num] [numeric](11, 2) NULL,
	[flow_no] [varchar](60) NULL,
	[vip_no] [varchar](20) NULL,
	[work_flag] [varchar](2) NOT NULL,
 CONSTRAINT [PK_VIP_NUM_TEMPCOST] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




/*==============================================================*/
/* Table: rm_vip_set                                            */
/*==============================================================*/
create table [WX_VIP].dbo.rm_vip_set (
   vip_item_cls         varchar(20)          collate Chinese_PRC_CI_AS not null,
   vip_amt              numeric(16,4)        null,
   vip_num              int                  null,
   other1               varchar(20)          collate Chinese_PRC_CI_AS null,
   num1                 numeric(16,4)        null,
   constraint PK_T_RM_VIP_SET primary key (vip_item_cls)
         on "PRIMARY"
)
 

INSERT INTO [WX_VIP].[dbo].[rm_vip_set]
           ([vip_item_cls]
           ,[vip_amt]
           ,[vip_num]
           ,[other1]
           ,[num1])
     VALUES
           ('0101'  
           ,1
           ,1
           ,Null
           ,0)
		   
alter table   [WX_Activity].[dbo].[ACT_SignUp]   add   Is_CancelOrBack      varchar(1)           null  default '0'
alter table   [WX_Activity].[dbo].[ACT_SignUp]   add    CancelSignUpNum      int                  null   default 0
alter table   [WX_Activity].[dbo].[ACT_SignUp]   add    refund_num       int                  null   default 0
 


 
/*==============================================================*/
/* Table: refund_table                                          */
/*==============================================================*/
create table  [WX_Activity].[dbo].refund_table (
   id                   int                  identity,
   refund_type          char(1)              null,
   open_ID              varchar(Max)         null,
   memo                 varchar(255)         collate Chinese_PRC_CI_AS null,
   release_person       varchar(Max)         null,
   release_time         datetime             null,
   release_memo         varchar(255)         collate Chinese_PRC_CI_AS null,
   flow_no              varchar(14)          null,
   constraint PK_REFUND_TABLE primary key (id)
)


/*==============================================================*/
/* Table: "t_ journal"                                          */
/*==============================================================*/
create table  [WX_Activity].[dbo].t_journal (
   id                   int                  identity,
   VerificationCode     varchar(Max)         null,
   oper_type            char(1)                null  ,
   oper_person          varchar(Max)         null,
   oper_time            datetime             null,
   Num                  int                  null,
   amount               numeric(16,2)        null,
   pay_way              char(3)              null,
   constraint "PK_T_ JOURNAL" primary key (id)
)


/*==============================================================*/
/* Table: t_Cancel_Sign                                         */
/*==============================================================*/
create table  [WX_Activity].[dbo].t_Cancel_Sign (
   id                   int                  identity,
   VerificationCode     varchar(Max)         null,
   oper_type            char(1)                 null ,
   oper_person          varchar(Max)         null,
   oper_time            datetime             null,
   Num                  int                  null,
   status               char(1)              null,
   memo                 varchar(255)        null,
   constraint PK_T_CANCEL_SIGN primary key (id)
)

/*==============================================================*/
/* Table: PublicInfo                                            */
/*==============================================================*/
create table [WX_SYSMGT].[dbo].PublicInfo (
   id                   int                  identity,
   info_Name            varchar(20) null,
   info_Value           varchar(20)          null,
   constraint PK_PUBLICINFO primary key (id)
)


INSERT INTO [WX_SYSMGT].[dbo].[PublicInfo]
           ([info_Name]
           ,[info_Value])
     VALUES
           ( 'Is_refund_Release' 
           , '1')