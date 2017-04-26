
CREATE TABLE [dbo].[tax_personals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personal_id] [varchar](50) NULL,
	[first_name] [varchar](150) NULL,
	[last_name] [varchar](150) NULL,
	[birth_date] [date] NULL,
	[personal_salary] [float] NULL,
	[is_provident_fund] [int] NULL,
	[provident_fund] [float] NULL,
	[is_parent_checked] [int] NULL,
	[is_childen_checked] [int] NULL,
	[is_cripple_checked] [int] NULL,
	[is_parent_dad_checked] [int] NULL,
	[is_parent_mom_checked] [int] NULL,
	[qty_cripple] [int] NULL,
	[qty_childen_nonstudy] [int] NULL,
	[qty_childen_domesticstudy] [int] NULL,
	[qty_childen_foreignstudy] [int] NULL,
	[is_single_checked] [int] NULL,
	[is_marry_checked] [int] NULL,
	[is_divorce_checked] [int] NULL,
	[is_marry_income] [int] NULL,
	[is_insuance_general] [int] NULL,
	[is_insuranc_pension] [int] NULL,
	[is_insurance_parents] [int] NULL,
	[insurance_general] [float] NULL,
	[insurance_pension] [float] NULL,
	[insurance_parents] [float] NULL,
	[social_insurance] [float] NULL,
	[is_ltf_invest] [float] NULL,
	[ltf_invest] [float] NULL,
	[is_rfd1] [int] NULL,
	[is_rfd2] [int] NULL,
	[is_rfd3] [int] NULL,
	[is_rfd4] [int] NULL,
	[rfd1] [float] NULL,
	[rfd2] [float] NULL,
	[rfd3] [float] NULL,
	[rfd4] [float] NULL,
	[is_have_interrset] [int] NULL,
	[interrest_home] [float] NULL,
	[is_donate] [int] NULL,
	[is_donate_general] [int] NULL,
	[is_donate_education] [int] NULL,
	[donate_general] [float] NULL,
	[donate_education] [float] NULL,
	[net_income] [float] NULL,
	[tax_rate] [float] NULL,
	[tax_money_rate] [float] NULL,
	[tax_rate_fix] [float] NULL,
	[exemsion] [float] NULL,
	[net_tax] [float] NULL,
	[expense] [float] NULL,
	[tax_year] [date] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL
)