SET MSG NONE;
SET UPDATECALC OFF;
SET AGGMISSG ON;
SET EMPTYMEMBERSETS ON;
SET FRMLBOTTOMUP ON;
SET CREATEBLOCKONEQ OFF;
SET CACHE ALL;
SET CACHE HIGH;
SET LOCKBLOCK HIGH;
SET CALCPARALLEL 1;
SET CALCTASKDIMS 1;
SET FRMLRTDYNAMIC OFF;


SET FRMLBOTTOMUP OFF;

FIX(rm_na
    FY17
    SCN_BUD
    VR_WORK
    @RELATIVE(YearTotal,0))
    FIX(Asset_NA
        icc_NA
        Product_NA)
        
        FIX(loc_6000000000T)
        
            FIX(iloc_1000000000T iloc_2000000000T iThrd_Party
                @RELATIVE(View_BS_Feed,0)
                lv_calc)
                FIX(cc_011702
                    acc_na)
                    CLEARDATA budget0007;
                ENDFIX
                
                FIX(cc_NA
                    acc_na)
                    budget0007(
                        cc_011702 =  @ALLOCATE(budget0007,@LIST(acc_BS0202010800,acc_BS0204010100,acc_BS0204010200),tune0012->BegBalance->cc_011702->lv_input,,multiply);
                    )
                ENDFIX
                
                FIX(cc_011702
                    acc_BS0202010800,acc_BS0204010100,acc_BS0204010200)
                    budget0007(
                        share0002 = budget0007 * BS0001->acc_na->lv_input /30;
                    )
                ENDFIX
            ENDFIX
            FIX(cc_011702
                lv_calc
                acc_BS0202010800,acc_BS0204010100,acc_BS0204010200
                share0002)
                FIX(iloc_1000000000T iloc_2000000000T iThrd_Party)
                    @IDESCENDANTS(View_BS_Feed,-1);
                ENDFIX
                FIX(@IDESCENDANTS(View_BS_Feed))
                    @IDESCENDANTS(iSgmt_total,-1);
                ENDFIX
            ENDFIX
            FIX(cc_011702
                lv_input
                acc_BS0202010800,acc_BS0204010100,acc_BS0204010200
                share0001)
                FIX(iloc_1000000000T iloc_2000000000T iThrd_Party)
                    @IDESCENDANTS(View_BS_Feed,-1);
                ENDFIX
                FIX(@IDESCENDANTS(View_BS_Feed))
                    @IDESCENDANTS(iSgmt_total,-1);
                ENDFIX
            ENDFIX
            
            FIX(cc_011702
                iloc_1000000000T
                View_BS_Feed
                acc_BS0204010100)
                FIX(lv_input)
                    share0001(
                        acc_BS0205010300->View_na->loc_1000000000T->iloc_6000000000T->lv_calc = share0001;
                    )
                ENDFIX
                FIX(lv_calc)
                    share0002(
                        acc_BS0205010300->View_na->loc_1000000000T->iloc_6000000000T->lv_calc = share0002;
                    )
                ENDFIX
            ENDFIX
        ENDFIX
    ENDFIX
ENDFIX