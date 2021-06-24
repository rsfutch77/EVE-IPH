﻿
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Public Module SettingsVariables

    ' All settings
    Public AllSettings As New ProgramSettings
    ' User Settings
    Public UserApplicationSettings As ApplicationSettings
    ' BP Tab Settings
    Public UserBPTabSettings As BPTabSettings
    ' Market History viewer
    Public UserMHViewerSettings As MarketHistoryViewerSettings
    ' Manufacturing
    Public UserManufacturingTabSettings As ManufacturingTabSettings
    ' Datacores
    Public UserDCTabSettings As DataCoreTabSettings
    ' Reactions Tab
    Public UserReactionTabSettings As ReactionsTabSettings
    ' Update Prices Tab Settings
    Public UserUpdatePricesTabSettings As UpdatePriceTabSettings
    ' Mining Tab Settings
    Public UserMiningTabSettings As MiningTabSettings
    ' Industry Job Column Settings
    Public UserIndustryJobsColumnSettings As IndustryJobsColumnSettings
    ' Manufacturing Tab Column Settings
    Public UserManufacturingTabColumnSettings As ManufacturingTabColumnSettings
    ' Shopping List settings
    Public UserShoppingListSettings As ShoppingListSettings
    ' Industry Flip Belt Settings
    Public UserIndustryFlipBeltSettings As IndustryFlipBeltSettings
    ' and the five belts
    Public UserIndustryFlipBeltOreCheckSettings1 As IndustryBeltOreChecks
    Public UserIndustryFlipBeltOreCheckSettings2 As IndustryBeltOreChecks
    Public UserIndustryFlipBeltOreCheckSettings3 As IndustryBeltOreChecks
    Public UserIndustryFlipBeltOreCheckSettings4 As IndustryBeltOreChecks
    Public UserIndustryFlipBeltOreCheckSettings5 As IndustryBeltOreChecks
    ' Asset windows - multiple
    Public UserAssetWindowDefaultSettings As AssetWindowSettings
    Public UserAssetWindowManufacturingTabSettings As AssetWindowSettings
    Public UserAssetWindowShoppingListSettings As AssetWindowSettings
    ' For LP store
    Public UserLPStoreSettings As LPStore
    ' For the Blueprint List Viewer
    Public UserBPViewerSettings As BPViewerSettings
    ' For Upwell Structure viewer
    Public UserUpwellStructureSettings As UpwellStructureSettings
    ' For bonus popout on structure viewer
    Public StructureBonusPopoutViewerSettings As StructureBonusPopoutSettings

End Module

Public Class ProgramSettings

    ' Default Tower Settings
    Public Const DefaultTowerName As String = None
    Public Const DefaultTowerRaceID As Integer = 0
    Public Const DefaultCostperHour As Integer = 0
    Public Const DefaultTowerType As String = "Standard"
    Public Const DefaultTowerSize As String = "Large"
    Public Const DefaultFuelBlockBuild As Boolean = False
    Public Const DefaultCharterCost As Double = 2500.0

    ' Application Setting Defaults
    Public MBeanCounterName As String = "Zainou 'Beancounter' Industry BX-80" ' Manufacturing time
    Public RBeanCounterName As String = "Zainou 'Beancounter' Reprocessing RX-80" ' Refining waste
    Public CBeanCounterName As String = "Zainou 'Beancounter' Science SC-80" ' Copy time

    Public DefaultCheckUpdatesOnStart As Boolean = True
    Public DefaultAllowSkillOverride As Boolean = False
    Public DefaultDataExportFormat As String = "Default"
    Public DefaultShowToolTips As Boolean = True
    Public DefaultLoadAssetsonStartup As Boolean = True
    Public DefaultLoadBPsonStartup As Boolean = True
    Public DefaultRefreshMarketESIDataonStartup As Boolean = True
    Public DefaultRefreshFacilityESIDataonStartup As Boolean = True
    Public DefaultRefreshPublicStructureDataonStartup As Boolean = True
    Public DefaultSupressESIStatusMessages As Boolean = False
    Public DefaultDisableSound As Boolean = False
    Public DefaultDNMarkInlineasOwned As Boolean = False
    Public DefaultSaveFacilitiesbyChar As Boolean = True
    Public DefaultLoadBPsbyChar As Boolean = True

    Public DefaultBuildBaseInstall As Double = 1000
    Public DefaultBuildBaseHourly As Double = 333
    Public DefaultBuildStandingDiscount As Double = 0.015
    Public DefaultBuildStandingSurcharge As Double = 0.005

    Public DefaultInventBaseInstall As Double = 10000
    Public DefaultInventBaseHourly As Double = 416.67
    Public DefaultInventStandingDiscount As Double = 0.015
    Public DefaultInventStandingSurcharge As Double = 0.005

    Public DefaultBuildCorpStanding As Double = 5.0 ' Corp standing of where this blueprint will be made
    Public DefaultInventCorpStanding As Double = 5.0 ' Corp standing of where this blueprint will be invented
    Public DefaultBrokerCorpStanding As Double = 5.0 ' Corp standing of where this blueprint will be sold
    Public DefaultBrokerFactionStanding As Double = 5.0 ' Faction standing of where this blueprint will be sold (for Broker calc)
    Public DefaultRefineCorpStanding As Double = 6.67 ' Corp standing for use of refining

    Public DefaultIncludeCopyTimes As Boolean = False ' If we include copy times in IPH calcs for invention
    Public DefaultIncludeInventionTimes As Boolean = False ' If we include invention times in IPH calcs for invention
    Public DefaultIncludeRETimes As Boolean = False ' If we include RE times in IPH calcs for RE

    Public DefaultEstimateCopyCost As Boolean = False ' Estimate copy costs for invention BPC's
    Public DefaultCopySlotModifier As String = "1.0" ' The default copy slot modifier for T1 BPC copies to use in invention
    Public DefaultInventionSlotModifier As String = "1.0" ' Default invention time
    Public DefaultBuildSlotModifier As String = "1.0" ' Default build time for production
    Public DefaultRefiningEfficency As Double = 0.5 ' Default refining equipment

    Public DefaultRefineTax As Double = 0.05 ' Default tax rate

    Public DefaultCheckBuildBuy As Boolean = False
    Public DefaultIgnoreRareandShipSkinBPs As Boolean = True
    Public DefaultSaveBPRelicsDecryptors As Boolean = False

    Public DefaultSettingME As Integer = 0
    Public DefaultSettingTE As Integer = 0

    Public DefaultDisableSVR As Boolean = False
    Public DefaultDisableGATracking As Boolean = False
    Public DefaultShareSavedFacilities As Boolean = True
    Public DefaultSuggestBuildBPNotOwned As Boolean = True ' If the bp is not owned, default to suggesting they build the item anyway

    Public DefaultAlphaAccount As Boolean = False
    Public DefaultUseActiveSkills As Boolean = False
    Public DefaultLoadMaxAlphaSkills As Boolean = False

    ' SVR Stuff
    Public DefaultIgnoreSVRThresholdValue As Double = 0.0
    Public DefaultSVRAveragePriceRegion As String = "The Forge"
    Public DefaultSVRAveragePriceDuration As String = "7"
    Public DefaultAutoUpdateSVRonBPTab As Boolean = True

    Public DefaultIncludeInGameLinksinCopyText As Boolean = False

    ' Proxy
    Public DefaultProxyAddress As String = ""
    Public DefaultProxyPort As Integer = 0

    ' For shopping list
    Public DefaultShopListIncludeInventMats As Boolean = True
    Public DefaultShopListIncludeCopyMats As Boolean = True

    ' If the user has no implants
    Public DefaultImplantValues As Double = 0

    Public FacilityDefaultMM As Double = 1
    Public FacilityDefaultTM As Double = 1
    Public FacilityDefaultCM As Double = 1
    Public FacilityDefaultTax As Double = 0.1 ' Only for processing
    Public OutpostDefaultTax As Double = 0 ' If we are saving the settings, then the only time would be for outposts

    Public FacilityDefaultActivityCostperSecond As Double = 0
    Public FacilityDefaultIncludeUsage As Boolean = True
    Public FacilityDefaultIncludeCost As Boolean = False ' Only for Invention, Copy, and RE so let this get set 
    Public FacilityDefaultIncludeTime As Boolean = False ' Only for Invention, Copy, and RE so let this get set 

    ' Set here, but use in Update Prices - 6 hours to refresh prices
    Public DefaultEVEMarketerRefreshInterval As Integer = 6

    Public DefaultBuiltMatsType As Integer = 1 ' use enum BuildMatType - both BP and Manufacturing tabs

    ' BP Tab Default settings
    Public DefaultBPTechChecks As Boolean = True
    Public DefaultSizeChecks As Boolean = False
    Public DefaultBPSelectionType As String = "All"
    Public DefaultBPIncludeFees As Integer = 0
    Public DefaultBPBrokerFeeRate As Double = 0.05
    Public DefaultBPIncludeTaxes As Boolean = True
    Public DefaultBPIncludeUsage As Boolean = True
    Public DefaultBPIgnoreChecks As Boolean = False
    Public DefaultBPPricePerUnit As Boolean = False
    Public DefaultBPIncludeInventionTime As Boolean = False
    Public DefaultBPIncludeInventionCost As Boolean = True
    Public DefaultBPIncludeCopyTime As Boolean = False
    Public DefaultBPIncludecopyCost As Boolean = True
    Public DefaultBPIncludeT3Cost As Boolean = False
    Public DefaultBPIncludeT3Time As Boolean = False
    Public DefaultBPSimpleCopyCheck As Boolean = False
    Public DefaultBPNPCBPOs As Boolean = False
    Public DefaultBPProductionLines As Integer = 1
    Public DefaultBPLaboratoryLines As Integer = 1
    Public DefaultBPRELines As Integer = 1
    Public DefaultBPRelicType As String = "" ' If they want to save and auto load relic types
    Public DefaultBPT3DecryptorType As String = "" ' if they want to save and auto load decryptors
    Public DefaultBPT2DecryptorType As String = "" ' if they want to save and auto load decryptors
    Public DefaultBPIgnoreInvention As Boolean = False
    Public DefaultBPIgnoreMinerals As Boolean = False
    Public DefaultBPIgnoreT1Item As Boolean = False
    Public DefaultBPIncludeIgnoredBPs As Boolean = False
    Public DefaultBPShoppingListExportType As String = "Components"
    Public DefaultBPCompColumnSort As Integer = 1
    Public DefaultBPCompColumnSortType As String = "Decending"
    Public DefaultBPRawColumnSort As Integer = 1
    Public DefaultBPRawColumnSortType As String = "Decending"
    Public DefaultBPRawProfitType As String = "Profit"
    Public DefaultBPCompProfitType As String = "Profit"
    Public DefaultBPCompressedOre As Boolean = False
    Public DefaultBPSellExcessItems As Boolean = True

    ' Update Prices Default Settings
    Public DefaultPriceChecks As Boolean = False
    Public DefaultPriceSystem As String = "Jita"
    Public DefaultPriceRegion As String = ""
    Public DefaultPriceRawMatsCombo As String = "Min Sell"
    Public DefaultPriceItemsCombo As String = "Min Sell"
    Public DefaultUPColumnSort As Integer = 1
    Public DefaultUPColumnSortType As String = "Ascending"
    Public DefaultRawPriceModifier As Double = 0
    Public DefaultItemsPriceModifier As Double = 0
    Public DefaultUseESIData As Boolean = False
    Public DefaultUsePriceProfile As Boolean = False
    Public DefaultPPRawPriceType As String = "Max Buy"
    Public DefaultPPRawRegion As String = "The Forge"
    Public DefaultPPRawSystem As String = "Jita"
    Public DefaultPPRawPriceMod As Double = 0
    Public DefaultPPItemsPriceType As String = "Min Sell"
    Public DefaultPPItemsRegion As String = "The Forge"
    Public DefaultPPItemsSystem As String = "Jita"
    Public DefaultPPItemsPriceMod As Double = 0

    ' Default Manufacturing Tab
    Public DefaultBlueprintType As String = "All Blueprints"
    Public DefaultCheckTech1 As Boolean = True
    Public DefaultCheckTech2 As Boolean = True
    Public DefaultCheckTech3 As Boolean = True
    Public DefaultCheckTechStoryline As Boolean = True
    Public DefaultCheckTechNavy As Boolean = True
    Public DefaultCheckTechPirate As Boolean = True
    Public DefaultItemTypeFilter As String = "All Types"
    Public DefaultTextItemFilter As String = ""
    Public DefaultCheckBPTypeShips As Boolean = True
    Public DefaultCheckBPTypeDrones As Boolean = True
    Public DefaultCheckBPTypeComponents As Boolean = True
    Public DefaultCheckBPTypeStructures As Boolean = True
    Public DefaultCheckBPTypeTools As Boolean = True
    Public DefaultCheckBPTypeModules As Boolean = True
    Public DefaultCheckBPTypeNPCBPOs As Boolean = False
    Public DefaultCheckBPTypeAmmoCharges As Boolean = True
    Public DefaultCheckBPTypeRigs As Boolean = True
    Public DefaultCheckBPTypeSubsystems As Boolean = True
    Public DefaultCheckBPTypeBoosters As Boolean = True
    Public DefaultCheckBPTypeDeployables As Boolean = True
    Public DefaultCheckBPTypeCelestials As Boolean = True
    Public DefaultCheckBPTypeReactions As Boolean = True
    Public DefaultCheckBPTypeStructureModules As Boolean = True
    Public DefaultCheckBPTypeStationParts As Boolean = True
    Public DefaultCheckDecryptorNone As Boolean = True
    Public DefaultCheckDecryptorOptimal As Integer = 0
    Public DefaultCheckDecryptor06 As Boolean = False
    Public DefaultCheckDecryptor09 As Boolean = False
    Public DefaultCheckDecryptor10 As Boolean = False
    Public DefaultCheckDecryptor11 As Boolean = False
    Public DefaultCheckDecryptor12 As Boolean = False
    Public DefaultCheckDecryptor15 As Boolean = False
    Public DefaultCheckDecryptor18 As Boolean = False
    Public DefaultCheckDecryptor19 As Boolean = False
    Public DefaultCheckDecryptorUseforT2 As Boolean = True
    Public DefaultCheckDecryptorUseforT3 As Boolean = True
    Public DefaultCheckIgnoreInvention As Boolean = False
    Public DefaultCheckRelicWrecked As Boolean = True
    Public DefaultCheckRelicIntact As Boolean = False
    Public DefaultCheckRelicMalfunction As Boolean = False
    Public DefaultCheckOnlyBuild As Boolean = False
    Public DefaultCheckOnlyInvent As Boolean = False
    Public DefaultCheckIncludeTaxes As Boolean = True
    Public DefaultIncludeBrokersFees As Integer = 0
    Public DefaultCalcBrokerFeeRate As Double = 0.05
    Public DefaultCheckIncludeUsage As Boolean = True
    Public DefaultCheckRaceAmarr As Boolean = True
    Public DefaultCheckRaceCaldari As Boolean = True
    Public DefaultCheckRaceGallente As Boolean = True
    Public DefaultCheckRaceMinmatar As Boolean = True
    Public DefaultCheckRacePirate As Boolean = True
    Public DefaultCheckRaceOther As Boolean = True
    Public DefaultPriceCompare As String = "Compare All"
    Public DefaultCheckIncludeT2Owned As Boolean = True
    Public DefaultCheckIncludeT3Owned As Boolean = True
    Public DefaultCheckSVRIncludeNull As Boolean = True
    Public DefaultCalcProductionLines As Integer = 1
    Public DefaultCalcLaboratoryLines As Integer = 1
    Public DefaultCalcRuns As Integer = 1
    Public DefaultCalcBPRuns As Integer = 1
    Public DefaultCheckAutoCalcNumBPs As Boolean = True
    Public DefaultCalcSizeChecks As Boolean = False
    Public DefaultCheckT3Destroyers As Boolean = False
    Public DefaultCheckCapComponents As Boolean = False
    Public DefaultCalcIgnoreInvention As Boolean = False
    Public DefaultCalcIgnoreMinerals As Boolean = False
    Public DefaultCalcIgnoreT1Item As Boolean = False
    Public DefaultCalcPPU As Boolean = False
    Public DefaultCalcManufacturingFWLevel As String = "0"
    Public DefaultCalcCopyingFWLevel As String = "0"
    Public DefaultCalcInventionFWLevel As String = "0"
    Public DefaultCalcColumnSort As Integer = 10 ' Default is sorting descending by IPH
    Public DefaultCalcColumnType As String = "Decending"
    Public DefaultCalcScore As Integer = 30
    Public DefaultCalcRiskProfit As Integer = 30
    Public DefaultCalcRiskIPH As Integer = 30
    Public DefaultCalcRiskPrice As Integer = 0
    Public DefaultCalcVolatility As Integer = 30
    Public DefaultCalcPriceTrend As String = "All"
    Public DefaultCalcMinBuildTime As String = "0 Days 00:00:00"
    Public DefaultCalcMinBuildTimeCheck As Boolean = False
    Public DefaultCalcMaxBuildTime As String = "1 Days 00:00:00"
    Public DefaultCalcMaxBuildTimeCheck As Boolean = False
    Public DefaultCalcIPHThreshold As Double = 0
    Public DefaultCalcIPHThresholdCheck As Boolean = False
    Public DefaultCalcProfitThreshold As Double = 0
    Public DefaultCalcProfitThresholdCheck As Integer = 0
    Public DefaultCalcVolumeThreshold As Double = 0
    Public DefaultCalcVolumeThresholdCheck As Boolean = False
    Public DefaultCalcSellExcessItems As Boolean = True

    ' Datacore Default Settings
    Public DefaultDCPricesFrom As String = "Updated Prices"
    Public DefaultDCCheckHighSec As Boolean = True
    Public DefaultDCCheckLowNullSec As Boolean = False
    Public DefaultDCIncludeAgentsCantUse As Boolean = False
    Public DefaultDCAgentsInRegion As String = "All Regions"
    Public DefaultDCSovCheck As Boolean = True
    Public DefaultDCColumnSort As Integer = 10
    Public DefaultDCColumnSortType As String = "Decending"

    ' Datacores For these, use the users settings
    Public DefaultConnections As Integer = -1
    Public DefaultNegotiation As Integer = -1
    Public DefaultResearchProjMgt As Integer = -1
    Public DefaultCorpStanding As Integer = -1
    Public DefaultCorpStandingChecked As Integer = -1
    Public DefaultSkillLevel As Integer = -1
    Public DefaultSkillLevelChecked As Integer = -1

    ' Datacore setting array sizes
    Public NumberofDCSettingsSkillRecords As Integer = 16
    Public NumberofDCSettingsCorpRecords As Integer = 12

    ' Reactions Default Settings
    Public DefaultReactPOSFuelCost As Double = 500000.0
    Public DefaultReactCheckTaxes As Boolean = True
    Public DefaultReactCheckFees As Boolean = True
    Public DefaultReactItemChecks As Boolean = False
    Public DefaultReactNumPOS As Integer = 1
    Public DefaultReactColumnSort As Integer = 5
    Public DefaultReactColumnSortType As String = "Decending"

    ' Mining Default Settings
    Public DefaultMiningOreType As String = "Ore"
    Public DefaultMiningCheckHighYieldOres As Boolean = False
    Public DefaultMiningCheckHighSecOres As Boolean = True
    Public DefaultMiningCheckLowSecOres As Boolean = False
    Public DefaultMiningCheckNullSecOres As Boolean = False
    Public DefaultMiningCheckSovAmarr As Boolean = True
    Public DefaultMiningCheckSovCaldari As Boolean = True
    Public DefaultMiningCheckSovGallente As Boolean = True
    Public DefaultMiningCheckSovMinmatar As Boolean = True
    Public DefaultMiningCheckSovTriglavian As Boolean = True
    Public DefaultMiningCheckSovWormhole As Boolean = True
    Public DefaultMiningCheckSovMoon As Boolean = True
    Public DefaultMiningCheckSovC1 As Boolean = True
    Public DefaultMiningCheckSovC2 As Boolean = True
    Public DefaultMiningCheckSovC3 As Boolean = True
    Public DefaultMiningCheckSovC4 As Boolean = True
    Public DefaultMiningCheckSovC5 As Boolean = True
    Public DefaultMiningCheckSovC6 As Boolean = True
    Public DefaultMiningCheckIncludeFees As Boolean = True
    Public DefaultMiningBrokerFeeRate As Double = 0.05
    Public DefaultMiningCheckIncludeTaxes As Boolean = True
    Public DefaultMiningCheckIncludeJumpFuelCosts As Boolean = False
    Public DefaultMiningTotalJumpFuelCost As Integer = 0
    Public DefaultMiningTotalJumpFuelM3 As Integer = 1
    Public DefaultMiningJumpCompressedOre As Boolean = True
    Public DefaultMiningJumpMinerals As Boolean = False
    Public DefaultMiningMiningShip As String = "" ' Keep this blank so that it will default to a ship for them, if they have the skills
    Public DefaultMiningIceMiningShip As String = "" ' Keep this blank so that it will default to a ship for them, if they have the skills
    Public DefaultMiningGasMiningShip As String = ""
    Public DefaultMiningOreStrip As String = "" ' Keep blank to set max possible strip/miner they can use
    Public DefaultMiningIceStrip As String = "" ' Keep blank so they can set the max possible ice strip
    Public DefaultMiningGasHarvester As String = ""
    Public DefaultMiningNumOreMiners As Integer = 0
    Public DefaultMiningNumIceMiners As Integer = 0
    Public DefaultMiningNumGasHarvesters As Integer = 0
    Public DefaultMiningOreUpgrade As String = None
    Public DefaultMiningIceUpgrade As String = None
    Public DefaultMiningGasUpgrade As String = None
    Public DefaultMiningNumOreUpgrades As Integer = 0
    Public DefaultMiningNumIceUpgrades As Integer = 0
    Public DefaultMiningNumGasUpgrades As Integer = 0
    Public DefaultMiningMichiiImplant As Boolean = False
    Public DefaultMiningT2Crystals As Boolean = False
    Public DefaultMiningOreImplant As String = None
    Public DefaultMiningIceImplant As String = None
    Public DefaultMiningGasImplant As String = None
    Public DefaultMiningCheckUseHauler As Boolean = True
    Public DefaultMiningRoundTripMin As Integer = 1
    Public DefaultMiningRoundTripSec As Integer = 0
    Public DefaultMiningHaulerm3 As Integer = 0
    Public DefaultMiningCheckUseFleetBooster As Boolean = False
    Public DefaultMiningBoosterShip As String = "Other"
    Public DefaultMiningBoosterShipSkill As Integer = 0
    Public DefaultMiningMiningFormanSkill As Integer = 0
    Public DefaultMiningMiningDirectorSkill As Integer = 0
    Public DefaultMiningWarfareLinkSpecSkill As Integer = 0
    Public DefaultMiningCheckMineForemanLaserOpBoost As Integer = 0
    Public DefaultMiningCheckMiningForemanMindLink As Boolean = False
    Public DefaultMiningRefineCorpTax As Double = 0.05
    Public DefaultMiningRorqDeployed As Integer = 0
    Public DefaultMiningDroneM3perHour As Double = 0.0
    Public DefaultMiningRefinedOre As Boolean = True
    Public DefaultMiningCompressedOre As Boolean = False
    Public DefaultMiningUnrefinedOre As Boolean = False
    Public DefaultMiningIndustrialReconfig As Integer = 0
    Public DefaultMiningRig As Boolean = False
    Public DefaultMiningNumberofMiners As Integer = 1
    Public DefaultMiningColumnSort As Integer = 8
    Public DefaultMiningColumnSortType As String = "Decending"

    ' Industry Jobs column settings
    Public DefaultJobState As Integer = 1
    Public DefaultInstallerName As Integer = 2
    Public DefaultTimeToComplete As Integer = 4
    Public DefaultActivity As Integer = 3
    Public DefaultStatus As Integer = 0
    Public DefaultStartTime As Integer = 0
    Public DefaultEndTime As Integer = 0
    Public DefaultCompletionTime As Integer = 0
    Public DefaultBlueprint As Integer = 5
    Public DefaultOutputItem As Integer = 6
    Public DefaultOutputItemType As Integer = 0
    Public DefaultInstallSolarSystem As Integer = 7
    Public DefaultInstallRegion As Integer = 8
    Public DefaultLicensedRuns As Integer = 0
    Public DefaultRuns As Integer = 0
    Public DefaultSuccessfulRuns As Integer = 0
    Public DefaultBlueprintLocation As Integer = 9
    Public DefaultOutputLocation As Integer = 10
    Public DefaultJobType As Integer = 11
    Public DefaultViewJobType As String = "Personal"
    Public DefaultJobTimes As String = "Current Jobs"
    Public DefaultSelectedCharacterIDs As String = ""
    Public DefaultIndustryColumnWidth As Integer = 100
    Public DefaultOrderByColumn As Integer = 3
    Public DefaultOrderType As String = "Ascending"
    Public DefaultAutoUpdateJobs As Boolean = True

    ' Column Names for industry jobs viewer
    Public Const JobStateColumn As String = "Job State"
    Public Const InstallerNameColumn As String = "Installer"
    Public Const TimetoCompleteColumn As String = "Time to Complete"
    Public Const ActivityColumn As String = "Activity"
    Public Const StatusColumn As String = "Status"
    Public Const StartTimeColumn As String = "Start Time"
    Public Const EndTimeColumn As String = "End Time"
    Public Const CompletionTimeColumn As String = "Completed Time"
    Public Const BlueprintColumn As String = "Blueprint"
    Public Const OutputItemColumn As String = "Output Item"
    Public Const OutputItemTypeColumn As String = "Output Item Type"
    Public Const InstallSolarSystemColumn As String = "Install System"
    Public Const InstallRegionColumn As String = "Install Region"
    Public Const LicensedRunsColumn As String = "Licensed Runs"
    Public Const RunsColumn As String = "Runs"
    Public Const SuccessfulRunsColumn As String = "Successful Runs"
    Public Const BlueprintLocationColumn As String = "Blueprint Location"
    Public Const OutputLocationColumn As String = "Output Location"
    Public Const JobTypeColumn As String = "Job Type"

    ' Manufacturing Tab column settings - index 0 is for hidden id column
    Public DefaultMTItemCategory As Integer = 1
    Public DefaultMTItemGroup As Integer = 0
    Public DefaultMTItemName As Integer = 2
    Public DefaultMTOwned As Integer = 3
    Public DefaultMTTech As Integer = 4
    Public DefaultMTBPME As Integer = 5
    Public DefaultMTBPTE As Integer = 6
    Public DefaultMTInputs As Integer = 7
    Public DefaultMTCompared As Integer = 8
    Public DefaultMTTotalRuns As Integer = 0
    Public DefaultMTSingleInventedBPCRuns As Integer = 0
    Public DefaultMTProductionLines As Integer = 0
    Public DefaultMTLaboratoryLines As Integer = 0
    Public DefaultMTTotalInventionCost As Integer = 0
    Public DefaultMTTotalCopyCost As Integer = 0
    Public DefaultMTTaxes As Integer = 0
    Public DefaultMTBrokerFees As Integer = 0
    Public DefaultMTBPProductionTime As Integer = 0
    Public DefaultMTTotalProductionTime As Integer = 0
    Public DefaultMTCopyTime As Integer = 0
    Public DefaultMTInventionTime As Integer = 0
    Public DefaultMTItemMarketPrice As Integer = 0
    Public DefaultMTProfit As Integer = 9
    Public DefaultMTProfitPercentage As Integer = 0
    Public DefaultMTIskperHour As Integer = 10
    Public DefaultMTSVR As Integer = 11
    Public DefaultMTSVRxIPH As Integer = 0
    Public DefaultMTRiskPrice As Integer = 0
    Public DefaultMTScore As Integer = 0
    Public DefaultMTRiskProfit As Integer = 0
    Public DefaultMTRiskIPH As Integer = 0
    Public DefaultMTVolatility As Integer = 0
    Public DefaultMTPriceTrend As Integer = 0
    Public DefaultMTTotalItemsSold As Integer = 0
    Public DefaultMTTotalOrdersFilled As Integer = 0
    Public DefaultMTAvgItemsperOrder As Integer = 0
    Public DefaultMTCurrentSellOrders As Integer = 0
    Public DefaultMTCurrentBuyOrders As Integer = 0
    Public DefaultMTItemsinProduction As Integer = 0
    Public DefaultMTItemsinStock As Integer = 0
    Public DefaultMTTotalCost As Integer = 12
    Public DefaultMTBaseJobCost As Integer = 0
    Public DefaultMTNumBPs As Integer = 0
    Public DefaultMTInventionChance As Integer = 0
    Public DefaultMTBPType As Integer = 0
    Public DefaultMTRace As Integer = 0
    Public DefaultMTVolumeperItem As Integer = 0
    Public DefaultMTTotalVolume As Integer = 0
    Public DefaultMTPortionSize As Integer = 0
    Public DefaultMTManufacturingJobFee As Integer = 0
    Public DefaultMTManufacturingFacilityName As Integer = 0
    Public DefaultMTManufacturingFacilitySystem As Integer = 0
    Public DefaultMTManufacturingFacilityRegion As Integer = 0
    Public DefaultMTManufacturingFacilitySystemIndex As Integer = 0
    Public DefaultMTManufacturingFacilityTax As Integer = 0
    Public DefaultMTManufacturingFacilityMEBonus As Integer = 0
    Public DefaultMTManufacturingFacilityTEBonus As Integer = 0
    Public DefaultMTManufacturingFacilityUsage As Integer = 0
    Public DefaultMTManufacturingFacilityFWSystemLevel As Integer = 0
    Public DefaultMTComponentFacilityName As Integer = 0
    Public DefaultMTComponentFacilitySystem As Integer = 0
    Public DefaultMTComponentFacilityRegion As Integer = 0
    Public DefaultMTComponentFacilitySystemIndex As Integer = 0
    Public DefaultMTComponentFacilityTax As Integer = 0
    Public DefaultMTComponentFacilityMEBonus As Integer = 0
    Public DefaultMTComponentFacilityTEBonus As Integer = 0
    Public DefaultMTComponentFacilityUsage As Integer = 0
    Public DefaultMTComponentFacilityFWSystemLevel As Integer = 0
    Public DefaultMTCapComponentFacilityName As Integer = 0
    Public DefaultMTCapComponentFacilitySystem As Integer = 0
    Public DefaultMTCapComponentFacilityRegion As Integer = 0
    Public DefaultMTCapComponentFacilitySystemIndex As Integer = 0
    Public DefaultMTCapComponentFacilityTax As Integer = 0
    Public DefaultMTCapComponentFacilityMEBonus As Integer = 0
    Public DefaultMTCapComponentFacilityTEBonus As Integer = 0
    Public DefaultMTCapComponentFacilityUsage As Integer = 0
    Public DefaultMTCapComponentFacilityFWSystemLevel As Integer = 0
    Public DefaultMTCopyingFacilityName As Integer = 0
    Public DefaultMTCopyingFacilitySystem As Integer = 0
    Public DefaultMTCopyingFacilityRegion As Integer = 0
    Public DefaultMTCopyingFacilitySystemIndex As Integer = 0
    Public DefaultMTCopyingFacilityTax As Integer = 0
    Public DefaultMTCopyingFacilityMEBonus As Integer = 0
    Public DefaultMTCopyingFacilityTEBonus As Integer = 0
    Public DefaultMTCopyingFacilityUsage As Integer = 0
    Public DefaultMTCopyingFacilityFWSystemLevel As Integer = 0
    Public DefaultMTInventionFacilityName As Integer = 0
    Public DefaultMTInventionFacilitySystem As Integer = 0
    Public DefaultMTInventionFacilityRegion As Integer = 0
    Public DefaultMTInventionFacilitySystemIndex As Integer = 0
    Public DefaultMTInventionFacilityTax As Integer = 0
    Public DefaultMTInventionFacilityMEBonus As Integer = 0
    Public DefaultMTInventionFacilityTEBonus As Integer = 0
    Public DefaultMTInventionFacilityUsage As Integer = 0
    Public DefaultMTInventionFacilityFWSystemLevel As Integer = 0
    Public DefaultMTReactionFacilityName As Integer = 0
    Public DefaultMTReactionFacilitySystem As Integer = 0
    Public DefaultMTReactionFacilityRegion As Integer = 0
    Public DefaultMTReactionFacilitySystemIndex As Integer = 0
    Public DefaultMTReactionFacilityTax As Integer = 0
    Public DefaultMTReactionFacilityMEBonus As Integer = 0
    Public DefaultMTReactionFacilityTEBonus As Integer = 0
    Public DefaultMTReactionFacilityUsage As Integer = 0
    Public DefaultMTReactionFacilityFWSystemLevel As Integer = 0

    Public DefaultMTItemCategoryWidth As Integer = 100
    Public DefaultMTItemGroupWidth As Integer = 100
    Public DefaultMTItemNameWidth As Integer = 225
    Public DefaultMTOwnedWidth As Integer = 50
    Public DefaultMTTechWidth As Integer = 37
    Public DefaultMTBPMEWidth As Integer = 28
    Public DefaultMTBPTEWidth As Integer = 28
    Public DefaultMTInputsWidth As Integer = 150
    Public DefaultMTComparedWidth As Integer = 80
    Public DefaultMTTotalRunsWidth As Integer = 64
    Public DefaultMTSingleInventedBPCRunsWidth As Integer = 138
    Public DefaultMTProductionLinesWidth As Integer = 92
    Public DefaultMTLaboratoryLinesWidth As Integer = 92
    Public DefaultMTTotalInventionCostWidth As Integer = 107
    Public DefaultMTTotalCopyCostWidth As Integer = 88
    Public DefaultMTTaxesWidth As Integer = 91
    Public DefaultMTBrokerFeesWidth As Integer = 100
    Public DefaultMTBPProductionTimeWidth As Integer = 106
    Public DefaultMTTotalProductionTimeWidth As Integer = 116
    Public DefaultMTCopyTimeWidth As Integer = 100
    Public DefaultMTInventionTimeWidth As Integer = 100
    Public DefaultMTItemMarketPriceWidth As Integer = 100
    Public DefaultMTProfitWidth As Integer = 100
    Public DefaultMTProfitPercentageWidth As Integer = 100
    Public DefaultMTIskperHourWidth As Integer = 100
    Public DefaultMTSVRWidth As Integer = 100
    Public DefaultMTSVRxIPHWidth As Integer = 100
    Public DefaultMTRiskPriceWidth As Integer = 100
    Public DefaultMTScoreWidth As Integer = 100
    Public DefaultMTRiskIPHWidth As Integer = 100
    Public DefaultMTRiskProfitWidth As Integer = 100
    Public DefaultMTVolatilityWidth As Integer = 100
    Public DefaultMTPriceTrendWidth As Integer = 100
    Public DefaultMTTotalItemsSoldWidth As Integer = 100
    Public DefaultMTTotalOrdersFilledWidth As Integer = 100
    Public DefaultMTAvgItemsperOrderWidth As Integer = 100
    Public DefaultMTCurrentSellOrdersWidth As Integer = 100
    Public DefaultMTCurrentBuyOrdersWidth As Integer = 100
    Public DefaultMTItemsinProductionWidth As Integer = 100
    Public DefaultMTItemsinStockWidth As Integer = 100
    Public DefaultMTTotalCostWidth As Integer = 100
    Public DefaultMTBaseJobCostWidth As Integer = 100
    Public DefaultMTNumBPsWidth As Integer = 57
    Public DefaultMTInventionChanceWidth As Integer = 100
    Public DefaultMTBPTypeWidth As Integer = 54
    Public DefaultMTRaceWidth As Integer = 77
    Public DefaultMTVolumeperItemWidth As Integer = 89
    Public DefaultMTTotalVolumeWidth As Integer = 75
    Public DefaultMTPortionSizeWidth As Integer = 75
    Public DefaultMTManufacturingJobFeeWidth As Integer = 122
    Public DefaultMTManufacturingFacilityNameWidth As Integer = 150
    Public DefaultMTManufacturingFacilitySystemWidth As Integer = 152
    Public DefaultMTManufacturingFacilityRegionWidth As Integer = 154
    Public DefaultMTManufacturingFacilitySystemIndexWidth As Integer = 184
    Public DefaultMTManufacturingFacilityTaxWidth As Integer = 138
    Public DefaultMTManufacturingFacilityMEBonusWidth As Integer = 169
    Public DefaultMTManufacturingFacilityTEBonusWidth As Integer = 166
    Public DefaultMTManufacturingFacilityUsageWidth As Integer = 149
    Public DefaultMTManufacturingFacilityFWSystemLevelWidth As Integer = 150
    Public DefaultMTComponentFacilityNameWidth As Integer = 145
    Public DefaultMTComponentFacilitySystemWidth As Integer = 140
    Public DefaultMTComponentFacilityRegionWidth As Integer = 138
    Public DefaultMTComponentFacilitySystemIndexWidth As Integer = 168
    Public DefaultMTComponentFacilityTaxWidth As Integer = 122
    Public DefaultMTComponentFacilityMEBonusWidth As Integer = 153
    Public DefaultMTComponentFacilityTEBonusWidth As Integer = 153
    Public DefaultMTComponentFacilityUsageWidth As Integer = 136
    Public DefaultMTComponentFacilityFWSystemLevelWidth As Integer = 150
    Public DefaultMTCapComponentFacilityNameWidth As Integer = 150
    Public DefaultMTCapComponentFacilitySystemWidth As Integer = 150
    Public DefaultMTCapComponentFacilityRegionWidth As Integer = 150
    Public DefaultMTCapComponentFacilitySystemIndexWidth As Integer = 150
    Public DefaultMTCapComponentFacilityTaxWidth As Integer = 150
    Public DefaultMTCapComponentFacilityMEBonusWidth As Integer = 150
    Public DefaultMTCapComponentFacilityTEBonusWidth As Integer = 150
    Public DefaultMTCapComponentFacilityUsageWidth As Integer = 150
    Public DefaultMTCapComponentFacilityFWSystemLevelWidth As Integer = 150
    Public DefaultMTCopyingFacilityNameWidth As Integer = 116
    Public DefaultMTCopyingFacilitySystemWidth As Integer = 122
    Public DefaultMTCopyingFacilityRegionWidth As Integer = 122
    Public DefaultMTCopyingFacilitySystemIndexWidth As Integer = 153
    Public DefaultMTCopyingFacilityTaxWidth As Integer = 107
    Public DefaultMTCopyingFacilityMEBonusWidth As Integer = 137
    Public DefaultMTCopyingFacilityTEBonusWidth As Integer = 135
    Public DefaultMTCopyingFacilityUsageWidth As Integer = 121
    Public DefaultMTCopyingFacilityFWSystemLevelWidth As Integer = 150
    Public DefaultMTInventionFacilityNameWidth As Integer = 122
    Public DefaultMTInventionFacilitySystemWidth As Integer = 130
    Public DefaultMTInventionFacilityRegionWidth As Integer = 129
    Public DefaultMTInventionFacilitySystemIndexWidth As Integer = 156
    Public DefaultMTInventionFacilityTaxWidth As Integer = 112
    Public DefaultMTInventionFacilityMEBonusWidth As Integer = 144
    Public DefaultMTInventionFacilityTEBonusWidth As Integer = 141
    Public DefaultMTInventionFacilityUsageWidth As Integer = 127
    Public DefaultMTInventionFacilityFWSystemLevelWidth As Integer = 150
    Public DefaultMTReactionFacilityNameWidth As Integer = 122
    Public DefaultMTReactionFacilitySystemWidth As Integer = 130
    Public DefaultMTReactionFacilityRegionWidth As Integer = 129
    Public DefaultMTReactionFacilitySystemIndexWidth As Integer = 156
    Public DefaultMTReactionFacilityTaxWidth As Integer = 112
    Public DefaultMTReactionFacilityMEBonusWidth As Integer = 144
    Public DefaultMTReactionFacilityTEBonusWidth As Integer = 141
    Public DefaultMTReactionFacilityUsageWidth As Integer = 127
    Public DefaultMTReactionFacilityFWSystemLevelWidth As Integer = 150

    Public DefaultMTOrderType As String = "Ascending"
    Public DefaultMTOrderByColumn As Integer = 3

    ' Column Names for manufacturing tab
    Public Const ItemCategoryColumnName As String = "Item Category"
    Public Const ItemGroupColumnName As String = "Item Group"
    Public Const ItemNameColumnName As String = "Item Name"
    Public Const OwnedColumnName As String = "Owned"
    Public Const TechColumnName As String = "Tech"
    Public Const BPMEColumnName As String = "ME"
    Public Const BPTEColumnName As String = "TE"
    Public Const InputsColumnName As String = "Inputs"
    Public Const ComparedColumnName As String = "Compared"
    Public Const TotalRunsColumnName As String = "Total Runs"
    Public Const SingleInventedBPCRunsColumnName As String = "Single Invented BPC Runs"
    Public Const ProductionLinesColumnName As String = "Production Lines"
    Public Const LaboratoryLinesColumnName As String = "Laboratory Lines"
    Public Const TotalInventionCostColumnName As String = "Total Invention Cost"
    Public Const TotalCopyCostColumnName As String = "Total Copy Cost"
    Public Const TaxesColumnName As String = "Taxes"
    Public Const BrokerFeesColumnName As String = "Broker Fees"
    Public Const BPProductionTimeColumnName As String = "BP Production Time"
    Public Const TotalProductionTimeColumnName As String = "Total Production Time"
    Public Const CopyTimeColumnName As String = "Copy Time"
    Public Const InventionTimeColumnName As String = "Invention Time"
    Public Const ItemMarketPriceColumnName As String = "Item Market Price"
    Public Const ProfitColumnName As String = "Profit"
    Public Const ProfitPercentageColumnName As String = "Profit Percentage"
    Public Const IskperHourColumnName As String = "Isk per Hour"
    Public Const SVRColumnName As String = "SVR"
    Public Const SVRxIPHColumnName As String = "SVR * IPH"
    Public Const PriceTrendColumnName As String = "Price Trend"
    Public Const ScoreColumnName As String = "Score"
    Public Const RiskProfitColumnName As String = "RiskProfit"
    Public Const RiskIPHColumnName As String = "RiskIPH"
    Public Const RiskPriceColumnName As String = "Risk Price"
    Public Const VolatilityColumnName As String = "Volatility"
    Public Const TotalItemsSoldColumnName As String = "Total Items Sold"
    Public Const TotalOrdersFilledColumnName As String = "Total Orders Filled"
    Public Const AvgItemsperOrderColumnName As String = "Average Items Per Order"
    Public Const CurrentSellOrdersColumnName As String = "Current Sell Orders"
    Public Const CurrentBuyOrdersColumnName As String = "Current Buy Orders"
    Public Const ItemsinProductionColumnName As String = "Items in Production"
    Public Const ItemsinStockColumnName As String = "Items in Stock"
    Public Const TotalCostColumnName As String = "Total Cost"
    Public Const BaseJobCostColumnName As String = "Base Job Cost"
    Public Const NumBPsColumnName As String = "Num BPs"
    Public Const InventionChanceColumnName As String = "Invention Chance"
    Public Const BPTypeColumnName As String = "BP Type"
    Public Const RaceColumnName As String = "Race"
    Public Const VolumeperItemColumnName As String = "Volume per Item"
    Public Const TotalVolumeColumnName As String = "Total Volume"
    Public Const PortionSizeColumnName As String = "Portion Size"
    Public Const ManufacturingJobFeeColumnName As String = "Manufacturing Job Fee"
    Public Const ManufacturingFacilityNameColumnName As String = "Manufacturing Facility Name"
    Public Const ManufacturingFacilitySystemColumnName As String = "Manufacturing Facility System"
    Public Const ManufacturingFacilityRegionColumnName As String = "Manufacturing Facility Region"
    Public Const ManufacturingFacilitySystemIndexColumnName As String = "Manufacturing Facility System Index"
    Public Const ManufacturingFacilityTaxColumnName As String = "Manufacturing Facility Tax"
    Public Const ManufacturingFacilityMEBonusColumnName As String = "Manufacturing Facility ME Bonus"
    Public Const ManufacturingFacilityTEBonusColumnName As String = "Manufacturing Facility TE Bonus"
    Public Const ManufacturingFacilityUsageColumnName As String = "Manufacturing Facility Usage"
    Public Const ManufacturingFacilityFWSystemLevelColumnName As String = "Manufacturing Facility FW System Level"
    Public Const ComponentFacilityNameColumnName As String = "Component Facility Name"
    Public Const ComponentFacilitySystemColumnName As String = "Component Facility System"
    Public Const ComponentFacilityRegionColumnName As String = "Component Facility Region"
    Public Const ComponentFacilitySystemIndexColumnName As String = "Component Facility System Index"
    Public Const ComponentFacilityTaxColumnName As String = "Component Facility Tax"
    Public Const ComponentFacilityMEBonusColumnName As String = "Component Facility ME Bonus"
    Public Const ComponentFacilityTEBonusColumnName As String = "Component Facility TE Bonus"
    Public Const ComponentFacilityUsageColumnName As String = "Component Facility Usage"
    Public Const ComponentFacilityFWSystemLevelColumnName As String = "Component Facility FW System Level"
    Public Const CapComponentFacilityNameColumnName As String = "Capital Component Facility Name"
    Public Const CapComponentFacilitySystemColumnName As String = "Capital Component Facility System"
    Public Const CapComponentFacilityRegionColumnName As String = "Capital Component Facility Region"
    Public Const CapComponentFacilitySystemIndexColumnName As String = "Capital Component Facility SystemIndex"
    Public Const CapComponentFacilityTaxColumnName As String = "Capital Component Facility Tax"
    Public Const CapComponentFacilityMEBonusColumnName As String = "Capital Component Facility ME Bonus"
    Public Const CapComponentFacilityTEBonusColumnName As String = "Capital Component Facility TE Bonus"
    Public Const CapComponentFacilityUsageColumnName As String = "Capital Component Facility Usage"
    Public Const CapComponentFacilityFWSystemLevelColumnName As String = "Capital Component Facility FW System Level"
    Public Const CopyingFacilityNameColumnName As String = "Copying Facility Name"
    Public Const CopyingFacilitySystemColumnName As String = "Copying Facility System"
    Public Const CopyingFacilityRegionColumnName As String = "Copying Facility Region"
    Public Const CopyingFacilitySystemIndexColumnName As String = "Copying Facility System Index"
    Public Const CopyingFacilityTaxColumnName As String = "Copying Facility Tax"
    Public Const CopyingFacilityMEBonusColumnName As String = "Copying Facility ME Bonus"
    Public Const CopyingFacilityTEBonusColumnName As String = "Copying Facility TE Bonus"
    Public Const CopyingFacilityUsageColumnName As String = "Copying Facility Usage"
    Public Const CopyingFacilityFWSystemLevelColumnName As String = "Copying Facility FW System Level"
    Public Const InventionFacilityNameColumnName As String = "Invention Facility Name"
    Public Const InventionFacilitySystemColumnName As String = "Invention Facility System"
    Public Const InventionFacilityRegionColumnName As String = "Invention Facility Region"
    Public Const InventionFacilitySystemIndexColumnName As String = "Invention Facility SystemIndex"
    Public Const InventionFacilityTaxColumnName As String = "Invention Facility Tax"
    Public Const InventionFacilityMEBonusColumnName As String = "Invention Facility ME Bonus"
    Public Const InventionFacilityTEBonusColumnName As String = "Invention Facility TE Bonus"
    Public Const InventionFacilityUsageColumnName As String = "Invention Facility Usage"
    Public Const InventionFacilityFWSystemLevelColumnName As String = "Invention Facility FW System Level"
    Public Const ReactionFacilityNameColumnName As String = "Reaction Facility Name"
    Public Const ReactionFacilitySystemColumnName As String = "Reaction Facility System"
    Public Const ReactionFacilityRegionColumnName As String = "Reaction Facility Region"
    Public Const ReactionFacilitySystemIndexColumnName As String = "Reaction Facility SystemIndex"
    Public Const ReactionFacilityTaxColumnName As String = "Reaction Facility Tax"
    Public Const ReactionFacilityMEBonusColumnName As String = "Reaction Facility ME Bonus"
    Public Const ReactionFacilityTEBonusColumnName As String = "Reaction Facility TE Bonus"
    Public Const ReactionFacilityUsageColumnName As String = "Reaction Facility Usage"
    Public Const ReactionFacilityFWSystemLevelColumnName As String = "Reaction Facility FW System Level"

    ' Industry Flip Belt settings
    Private DefaultCycleTime As Double = 180
    Private Defaultm3perCycle As Double = 3000
    Private DefaultNumMiners As Integer = 1
    Private DefaultCompressOre As Boolean = False
    Private DefaultIPHperMiner As Boolean = False
    Private DefaultIncludeBrokerFees As Integer '0,1,2 - Tri-check
    Private DefaultBFBrokerFeeRate As Double = 0.05
    Private DefaultIncludeTaxes As Boolean = True
    Private DefaultTruesec As String = ""

    ' Industry flip belt defaults
    Private DefaultPlagioclase As Boolean = True
    Private DefaultSpodumain As Boolean = True
    Private DefaultKernite As Boolean = True
    Private DefaultHedbergite As Boolean = True
    Private DefaultArkonor As Boolean = True
    Private DefaultBistot As Boolean = True
    Private DefaultPyroxeres As Boolean = True
    Private DefaultCrokite As Boolean = True
    Private DefaultJaspet As Boolean = True
    Private DefaultOmber As Boolean = True
    Private DefaultScordite As Boolean = True
    Private DefaultGneiss As Boolean = True
    Private DefaultVeldspar As Boolean = True
    Private DefaultHemorphite As Boolean = True
    Private DefaultDarkOchre As Boolean = True
    Private DefaultMercoxit As Boolean = True
    Private DefaultCrimsonArkonor As Boolean = True
    Private DefaultPrimeArkonor As Boolean = True
    Private DefaultTriclinicBistot As Boolean = True
    Private DefaultMonoclinicBistot As Boolean = True
    Private DefaultSharpCrokite As Boolean = True
    Private DefaultCrystallineCrokite As Boolean = True
    Private DefaultOnyxOchre As Boolean = True
    Private DefaultObsidianOchre As Boolean = True
    Private DefaultVitricHedbergite As Boolean = True
    Private DefaultGlazedHedbergite As Boolean = True
    Private DefaultVividHemorphite As Boolean = True
    Private DefaultRadiantHemorphite As Boolean = True
    Private DefaultPureJaspet As Boolean = True
    Private DefaultPristineJaspet As Boolean = True
    Private DefaultLuminousKernite As Boolean = True
    Private DefaultFieryKernite As Boolean = True
    Private DefaultAzurePlagioclase As Boolean = True
    Private DefaultRichPlagioclase As Boolean = True
    Private DefaultSolidPyroxeres As Boolean = True
    Private DefaultViscousPyroxeres As Boolean = True
    Private DefaultCondensedScordite As Boolean = True
    Private DefaultMassiveScordite As Boolean = True
    Private DefaultBrightSpodumain As Boolean = True
    Private DefaultGleamingSpodumain As Boolean = True
    Private DefaultConcentratedVeldspar As Boolean = True
    Private DefaultDenseVeldspar As Boolean = True
    Private DefaultIridescentGneiss As Boolean = True
    Private DefaultPrismaticGneiss As Boolean = True
    Private DefaultSilveryOmber As Boolean = True
    Private DefaultGoldenOmber As Boolean = True
    Private DefaultMagmaMercoxit As Boolean = True
    Private DefaultVitreousMercoxit As Boolean = True

    ' Default Shopping List Settings
    Private DefaultAlwaysonTop As Boolean = False
    Private DefaultUpdateAssetsWhenUsed As Boolean = False
    Private DefaultFees As Boolean = True
    Private DefaultCalcBuyBuyOrder As Integer = 1
    Private DefaultUsage As Boolean = True
    Private DefaultReloadBPsFromFile As Boolean = True

    ' Default Market History Viewer Settings
    Private DefaultMHDatePreference As String = "By Days"
    Private DefaultMHVolume As Boolean = False
    Private DefaultMHMinMaxDayPrice As Boolean = False
    Private DefaultMHLinearTrend As Boolean = False
    Private DefaultMHDochianChannel As Boolean = False
    Private DefaultMHFiveDayAvg As Boolean = False
    Private DefaultMHTwentyDayAvg As Boolean = False

    ' Assets - Item Checks
    Private DefaultAssetItemChecks As Boolean = True
    Private DefaultAssetItemTextFilter As String = ""
    Private DefaultAllItems As Boolean = True
    ' Assets - Main window 
    Private DefaultAssetType As String = "Both"
    Private DefaultAssetSortbyName As Boolean = True

    ' Default LP Store
    Private DefaultLPRewardType As String = "All"
    Private DefaultLPCorpFilter As String = "Use Standings"
    Private DefaultLPCheckAgentLevel1 As Boolean = True
    Private DefaultLPCheckAgentLevel2 As Boolean = True
    Private DefaultLPCheckAgentLevel3 As Boolean = True
    Private DefaultLPCheckAgentLevel4 As Boolean = True
    Private DefaultLPCheckAgentLevel5 As Boolean = True
    Private DefaultLPTextItemSearch As String = ""
    Private DefaultLPTextReqItemSearch As String = ""
    Private DefaultLPLPCostLessThan As String = "0.00"
    Private DefaultLPLPCostGreaterThan As String = "0.00"
    Private DefaultLPISKCostLessThan As String = "0.00"
    Private DefaultLPISKCostGreaterThan As String = "0.00"
    Private DefaultLPStandingLessThan As String = "0.00"
    Private DefaultLPStandingGreaterThan As String = "0.00"
    Private DefaultLPSearchOption As String = "All Corporations"
    Private DefaultLPSortByOption As String = "ISK/LP"
    Private DefaultLPHighlightCheck As Boolean = True
    Private DefaultLPSelectedCorporations As String = ""

    ' Upwell Structures Viewer
    Private DefaultHighSlotsCheck As Boolean = False
    Private DefaultMediumSlotsCheck As Boolean = False
    Private DefaultLowSlotsCheck As Boolean = False
    Private DefaultServicesCheck As Boolean = False
    Private DefaultReprocessingRigsCheck As Boolean = False
    Private DefaultEngineeringRigsCheck As Boolean = False
    Private DefaultCombatRigsCheck As Boolean = False
    Private DefaultIncludeFuelCostsCheck As Boolean = False
    Private DefaultFuelBlockType As String = "Helium Fuel Block"
    Private DefaultBuyBuildBlockOption As String = "Buy Blocks"
    Private DefaultAutoUpdateFuelBlockPricesCheck As Boolean = False
    Private DefaultSearchFilterText As String = ""
    Private DefaultSelectedStructureName As String = "Raitaru"
    Private DefaultReactionsRigsCheck As Boolean = False
    Private DefaultDrillingRigsCheck As Boolean = False
    Private DefaultIconListView As Boolean = True

    ' Bonus Popout Viewer Settings for facilities
    Private DefaultSBPVFormWidth As Integer = 750
    Private DefaultSBPVFormHeight As Integer = 275
    Private DefaultSBPVBonusAppliesColumnWidth As Integer = 150
    Private DefaultSBPVActivityColumnWidth As Integer = 125
    Private DefaultSBPVBonusesColumnWidth As Integer = 250
    Private DefaultSBPVBonusSourceColumnWidth As Integer = 165

    ' Local versions of settings
    Private ApplicationSettings As ApplicationSettings
    Private BPSettings As BPTabSettings
    Private ManufacturingSettings As ManufacturingTabSettings
    Private DatacoreSettings As DataCoreTabSettings
    Private ReactionSettings As ReactionsTabSettings
    Private MiningSettings As MiningTabSettings
    Private UpdatePricesSettings As UpdatePriceTabSettings
    Private IndustryJobsColumnSettings As IndustryJobsColumnSettings
    Private ManufacturingTabColumnSettings As ManufacturingTabColumnSettings
    Private IndustryFlipBeltsSettings As IndustryFlipBeltSettings
    Private ShoppingListTabSettings As ShoppingListSettings
    Private LPStoreSettings As LPStore
    Private MarketHistoryViewSettings As MarketHistoryViewerSettings
    Private UpwellStructureViewerSettings As UpwellStructureSettings
    Private BPViewSettings As BPViewerSettings

    ' Multiple versions of Asset windows
    Private AssetWindowSettingsManufacturingTab As AssetWindowSettings
    Private AssetWindowSettingsShoppingList As AssetWindowSettings

    ' 5 belt types
    Private IndustryBeltOreChecksSettings1 As IndustryBeltOreChecks
    Private IndustryBeltOreChecksSettings2 As IndustryBeltOreChecks
    Private IndustryBeltOreChecksSettings3 As IndustryBeltOreChecks
    Private IndustryBeltOreChecksSettings4 As IndustryBeltOreChecks
    Private IndustryBeltOreChecksSettings5 As IndustryBeltOreChecks

    Private Const AppSettingsFileName As String = "ApplicationSettings"
    Private Const BPSettingsFileName As String = "BPTabSettings"
    Private Const ManufacturingSettingsFileName As String = "ManufacturingTabSettings"
    Private Const UpdatePricesFileName As String = "UpdatePricesSettings"
    Private Const DatacoreSettingsFileName As String = "DatacoreSettings"
    Private Const ReactionSettingsFileName As String = "ReactionTabSettings"
    Private Const MiningSettingsFileName As String = "MiningTabSettings"
    Private Const IndustryJobsColumnSettingsFileName As String = "IndustryJobsColumnSettings"
    Private Const ManufacturingTabColumnSettingsFileName As String = "ManufacturingTabColumnSettings"
    Private Const IndustryFlipBeltSettingsFileName As String = "IndustryFlipBeltSettings"
    Private Const ShoppingListSettingsFileName As String = "ShoppingListSettings"
    Private Const BPViewerSettingsFileName As String = "BPViewerSettings"

    Private Const LPStoreSettingsFileName As String = "LPStoreSettings"
    Private Const MarketHistoryViewerSettingsFileName As String = "MarketHistoryViewerSettings"
    Private Const UpwellStructureViewerSettingsFileName As String = "UpwellStructureViewerSettings"
    Private Const StructureBonusPopoutViewerSettingsFileName As String = "StructureBonusPopoutViewerSettings"

    ' For BP List Viewer
    Public DefaultBPViewerTechChecks As Boolean = True
    Public DefaultBPViewerSizeChecks As Boolean = False
    Public DefaultBPViewerIgnoreBPsCheck As Boolean = False
    Public DefaultBPNPCBPOsCheck As Boolean = False
    Public DefaultBPViewerSelectionType As String = "All"

    ' 5 belts
    Private IndustryBeltOreChecksBaseFileName As String = "IndustryBeltOreChecks"
    Private IndustryBeltOreChecksFileName As String = ""
    Private Const IndustryBeltOreChecksFileName1 As String = "1"
    Private Const IndustryBeltOreChecksFileName2 As String = "2"
    Private Const IndustryBeltOreChecksFileName3 As String = "3"
    Private Const IndustryBeltOreChecksFileName4 As String = "4"
    Private Const IndustryBeltOreChecksFileName5 As String = "5"

    ' Multiple asset windows
    Private Const AssetWindowFileNameDefault As String = "AssetWindowSettingsDefault"
    Private Const AssetWindowFileNameManufacturingTab As String = "AssetWindowSettingsManufacturingTab"
    Private Const AssetWindowFileNameShoppingList As String = "AssetWindowSettingsShoppingList"

    Private Const XMLfileType As String = ".xml"

    Public Sub New()
        ApplicationSettings = Nothing
        MiningSettings = Nothing
        BPSettings = Nothing
        ManufacturingSettings = Nothing
        DatacoreSettings = Nothing
        ReactionSettings = Nothing
        MiningSettings = Nothing
        UpdatePricesSettings = Nothing
        IndustryJobsColumnSettings = Nothing
        ManufacturingTabColumnSettings = Nothing
        IndustryFlipBeltsSettings = Nothing
        ShoppingListTabSettings = Nothing
        LPStoreSettings = Nothing
        MarketHistoryViewSettings = Nothing
        UpwellStructureViewerSettings = Nothing
        BPViewSettings = Nothing

    End Sub

    ' Writes the sent settings to the sent file name
    Private Sub WriteSettingsToFile(FileFolder As String, FileName As String, Settings As Setting(), RootName As String)
        Dim i As Integer

        ' Create XmlWriterSettings.
        Dim XMLSettings As XmlWriterSettings = New XmlWriterSettings()
        Dim FilePath As String = Path.Combine(DynamicFilePath, FileFolder)
        XMLSettings.Indent = True

        If FileFolder <> "" Then
            If Not Directory.Exists(FilePath) Then
                ' Create the settings folder
                Directory.CreateDirectory(FilePath)
            End If
        End If

        ' Delete and make a fresh copy
        If File.Exists(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType)) Then
            File.Delete(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType))
        End If

        ' Loop through the settings sent and output each name and value
        Using writer As XmlWriter = XmlWriter.Create(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType), XMLSettings)
            writer.WriteStartDocument()
            writer.WriteStartElement(RootName) ' Root.

            ' Main loop
            For i = 0 To Settings.Count - 1
                writer.WriteElementString(Settings(i).Name, Settings(i).Value)
            Next

            ' End document.
            writer.WriteEndDocument()
        End Using

    End Sub

    ' Gets a value from a referenced XML file by searching for it
    Private Function GetSettingValue(FileFolder As String, ByRef FileName As String, ObjectType As SettingTypes,
                                     RootElement As String, ElementString As String,
                                     DefaultValue As Object) As Object
        Dim m_xmld As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim FilePath As String = Path.ChangeExtension(Path.Combine(DynamicFilePath, FileFolder, FileName), XMLfileType)
        Dim TempValue As String

        Try


            'Load the Xml file
            m_xmld.Load(FilePath)

            'Get the settings
            m_nodelist = m_xmld.SelectNodes("/" & RootElement & "/" & ElementString)

            If Not IsNothing(m_nodelist.Item(0)) Then
                ' Should only be one
                TempValue = m_nodelist.Item(0).InnerText

                ' If blank, then return default
                If TempValue = "" Then
                    Return DefaultValue
                End If

                If TempValue = "False" Or TempValue = "True" Then
                    ' Change to type boolean
                    ObjectType = SettingTypes.TypeBoolean
                End If

                ' Found it, return the cast
                Select Case ObjectType
                    Case SettingTypes.TypeBoolean
                        Return CBool(TempValue)
                    Case SettingTypes.TypeDouble
                        Return CDbl(TempValue)
                    Case SettingTypes.TypeInteger
                        Return CInt(TempValue)
                    Case SettingTypes.TypeString
                        Return CStr(TempValue)
                    Case SettingTypes.TypeLong
                        Return CLng(TempValue)
                End Select

            Else
                ' Doesn't exist, use default
                Return DefaultValue
            End If

        Catch ex As Exception
            ' Threw an error, so return the default value
            Return DefaultValue
        End Try

        Return Nothing

    End Function

    ' Just checks if the file exists or not so we don't have to mess with file names
    Private Function FileExists(FileFolder As String, FileName As String) As Boolean

        If File.Exists(Path.ChangeExtension(Path.Combine(DynamicFilePath, FileFolder, FileName), XMLfileType)) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Structure Setting
        Dim Name As String
        Dim Value As String

        Public Sub New(inName As String, inValue As String)
            Name = inName
            Value = inValue
        End Sub

    End Structure

    Private Enum SettingTypes
        TypeInteger = 1
        TypeDouble = 2
        TypeString = 3
        TypeBoolean = 4
        TypeLong = 5
    End Enum

#Region "Application Settings"

    ' Loads the settings for the user from the DB (for now) for the whole program
    Public Function LoadApplicationSettings() As ApplicationSettings
        Dim TempSettings As ApplicationSettings = Nothing

        Try
            If FileExists(SettingsFolder, AppSettingsFileName) Then

                'Get the settings
                With TempSettings
                    .CheckforUpdatesonStart = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "CheckforUpdatesonStart", DefaultCheckUpdatesOnStart))
                    .LoadAssetsonStartup = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadAssetsonStartup", DefaultLoadAssetsonStartup))
                    .LoadBPsonStartup = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadbpsonStartup", DefaultLoadBPsonStartup))
                    .LoadESIMarketDataonStartup = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESIMarketDataonStartup", DefaultRefreshMarketESIDataonStartup))
                    .LoadESISystemCostIndiciesDataonStartup = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESISystemCostIndiciesDataonStartup", DefaultRefreshFacilityESIDataonStartup))
                    .LoadESIPublicStructuresonStartup = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESISystemCostIndiciesDataonStartup", DefaultRefreshPublicStructureDataonStartup))
                    .SupressESIStatusMessages = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "SupressESIStatusMessages", DefaultSupressESIStatusMessages))
                    .DataExportFormat = CStr(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeString, AppSettingsFileName, "DataExportFormat", DefaultDataExportFormat))
                    .AllowSkillOverride = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AllowSkillOverride", DefaultAllowSkillOverride))
                    .ShowToolTips = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "ShowToolTips", DefaultShowToolTips))
                    .RefiningImplantValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "RefiningImplantValue", DefaultImplantValues))
                    .ManufacturingImplantValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "ManufacturingImplantValue", DefaultImplantValues))
                    .CopyImplantValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "CopyImplantValue", DefaultImplantValues))
                    .BrokerCorpStanding = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerCorpStanding", DefaultBrokerCorpStanding))
                    .IncludeInGameLinksinCopyText = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "IncludeInGameLinksinCopyText", DefaultIncludeInGameLinksinCopyText))
                    .BrokerFactionStanding = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerFactionStanding", DefaultBrokerFactionStanding))
                    .DefaultBPME = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPME", DefaultSettingME))
                    .DefaultBPTE = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPTE", DefaultSettingTE))
                    .CheckBuildBuy = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "CheckBuildBuy", DefaultCheckBuildBuy))
                    .DisableSVR = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableSVR", DefaultDisableSVR))
                    .DisableGATracking = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableGATracking", DefaultDisableGATracking))
                    .ShopListIncludeInventMats = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "ShopListIncludeInventMats", DefaultShopListIncludeInventMats))
                    .ShopListIncludeCopyMats = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "ShopListIncludeCopyMats", DefaultShopListIncludeCopyMats))
                    .SuggestBuildBPNotOwned = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "SuggestBuildBPNotOwned", DefaultSuggestBuildBPNotOwned))
                    .EVEMarketerRefreshInterval = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "EVEMarketerRefreshInterval", DefaultEVEMarketerRefreshInterval))
                    .DisableSound = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableSound", DefaultDisableSound))
                    .SaveBPRelicsDecryptors = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "SaveBPRelicsDecryptors", DefaultSaveBPRelicsDecryptors))
                    .IgnoreSVRThresholdValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "IgnoreSVRThresholdValue", DefaultIgnoreSVRThresholdValue))
                    .SVRAveragePriceRegion = CStr(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeString, AppSettingsFileName, "SVRAveragePriceRegion", DefaultSVRAveragePriceRegion))
                    .SVRAveragePriceDuration = CStr(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeString, AppSettingsFileName, "SVRAveragePriceDuration", DefaultSVRAveragePriceDuration))
                    .AutoUpdateSVRonBPTab = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AutoUpdateSVRonBPTab", DefaultAutoUpdateSVRonBPTab))
                    .ProxyAddress = CStr(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeString, AppSettingsFileName, "ProxyAddress", DefaultProxyAddress))
                    .ProxyPort = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "ProxyPort", DefaultProxyPort))
                    .SaveFacilitiesbyChar = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "SaveFacilitiesbyChar", DefaultSaveFacilitiesbyChar))
                    .LoadBPsbyChar = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadBPsbyChar", DefaultLoadBPsbyChar))
                    .AlphaAccount = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AlphaAccount", DefaultAlphaAccount))
                    .UseActiveSkillLevels = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "UseActiveSkillLevels", DefaultUseActiveSkills))
                    .LoadMaxAlphaSkills = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadMaxAlphaSkills", DefaultLoadMaxAlphaSkills))
                    .ShareSavedFacilities = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "ShareSavedFacilities", DefaultDisableGATracking))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultApplicationSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Application Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Some other error occured Load defaults 
            TempSettings = SetDefaultApplicationSettings()
        End Try

        ' Save them locally and then export
        ApplicationSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the defaults
    Public Function SetDefaultApplicationSettings() As ApplicationSettings
        Dim TempSettings As ApplicationSettings

        With TempSettings
            ' Load default settings
            .CheckforUpdatesonStart = DefaultCheckUpdatesOnStart
            .DataExportFormat = DefaultDataExportFormat
            .ShowToolTips = DefaultShowToolTips
            .LoadAssetsonStartup = DefaultLoadAssetsonStartup
            .LoadBPsonStartup = DefaultLoadBPsonStartup
            .LoadESIMarketDataonStartup = DefaultRefreshMarketESIDataonStartup
            .SupressESIStatusMessages = DefaultSupressESIStatusMessages
            .LoadESISystemCostIndiciesDataonStartup = DefaultRefreshFacilityESIDataonStartup
            .LoadESIPublicStructuresonStartup = DefaultRefreshPublicStructureDataonStartup
            .DisableSound = DefaultDisableSound
            .ManufacturingImplantValue = DefaultImplantValues
            .RefiningImplantValue = DefaultImplantValues
            .CopyImplantValue = DefaultImplantValues

            ' Station Standings for building and selling
            .BrokerCorpStanding = DefaultBrokerCorpStanding
            .BrokerFactionStanding = DefaultBrokerFactionStanding

            .CheckBuildBuy = DefaultCheckBuildBuy

            .DefaultBPME = DefaultSettingME
            .DefaultBPTE = DefaultSettingTE

            .AlphaAccount = DefaultAlphaAccount
            .UseActiveSkillLevels = DefaultUseActiveSkills
            .LoadMaxAlphaSkills = DefaultLoadMaxAlphaSkills

            .DisableSVR = DefaultDisableSVR
            .DisableGATracking = DefaultDisableGATracking
            .ShareSavedFacilities = DefaultShareSavedFacilities
            .SuggestBuildBPNotOwned = DefaultSuggestBuildBPNotOwned
            .SaveBPRelicsDecryptors = DefaultSaveBPRelicsDecryptors

            .ShopListIncludeInventMats = DefaultShopListIncludeInventMats
            .ShopListIncludeCopyMats = DefaultShopListIncludeCopyMats

            .EVEMarketerRefreshInterval = DefaultEVEMarketerRefreshInterval

            .IgnoreSVRThresholdValue = DefaultIgnoreSVRThresholdValue
            .SVRAveragePriceRegion = DefaultSVRAveragePriceRegion
            .SVRAveragePriceDuration = DefaultSVRAveragePriceDuration
            .AutoUpdateSVRonBPTab = DefaultAutoUpdateSVRonBPTab

            .ProxyAddress = DefaultProxyAddress
            .ProxyPort = DefaultProxyPort

            .LoadBPsbyChar = DefaultLoadBPsbyChar
            .SaveFacilitiesbyChar = DefaultSaveFacilitiesbyChar
        End With

        ' Save locally
        ApplicationSettings = TempSettings
        Return TempSettings

    End Function

    ' Saves the application settings to XML
    Public Sub SaveApplicationSettings(SentSettings As ApplicationSettings)
        Dim ApplicationSettingsList(37) As Setting

        Try
            ApplicationSettingsList(0) = New Setting("CheckforUpdatesonStart", CStr(SentSettings.CheckforUpdatesonStart))
            ApplicationSettingsList(1) = New Setting("DataExportFormat", CStr(SentSettings.DataExportFormat))
            ApplicationSettingsList(2) = New Setting("AllowSkillOverride", CStr(SentSettings.AllowSkillOverride))
            ApplicationSettingsList(3) = New Setting("ShowToolTips", CStr(SentSettings.ShowToolTips))
            ApplicationSettingsList(4) = New Setting("RefiningImplantValue", CStr(SentSettings.RefiningImplantValue))
            ApplicationSettingsList(5) = New Setting("ManufacturingImplantValue", CStr(SentSettings.ManufacturingImplantValue))
            ApplicationSettingsList(6) = New Setting("CopyImplantValue", CStr(SentSettings.CopyImplantValue))
            ApplicationSettingsList(7) = New Setting("BrokerCorpStanding", CStr(SentSettings.BrokerCorpStanding))
            ApplicationSettingsList(8) = New Setting("BrokerFactionStanding", CStr(SentSettings.BrokerFactionStanding))
            ApplicationSettingsList(9) = New Setting("DefaultBPME", CStr(SentSettings.DefaultBPME))
            ApplicationSettingsList(10) = New Setting("DefaultBPTE", CStr(SentSettings.DefaultBPTE))
            ApplicationSettingsList(11) = New Setting("CheckBuildBuy", CStr(SentSettings.CheckBuildBuy))
            ApplicationSettingsList(12) = New Setting("IncludeInGameLinksinCopyText", CStr(SentSettings.IncludeInGameLinksinCopyText))
            ApplicationSettingsList(13) = New Setting("ShopListIncludeInventMats", CStr(SentSettings.ShopListIncludeInventMats))
            ApplicationSettingsList(14) = New Setting("ShopListIncludeCopyMats", CStr(SentSettings.ShopListIncludeCopyMats))
            ApplicationSettingsList(15) = New Setting("SuggestBuildBPNotOwned", CStr(SentSettings.SuggestBuildBPNotOwned))
            ApplicationSettingsList(16) = New Setting("EVEMarketerRefreshInterval", CStr(SentSettings.EVEMarketerRefreshInterval))
            ApplicationSettingsList(17) = New Setting("LoadAssetsonStartup", CStr(SentSettings.LoadAssetsonStartup))
            ApplicationSettingsList(18) = New Setting("DisableSound", CStr(SentSettings.DisableSound))
            ApplicationSettingsList(19) = New Setting("LoadbpsonStartup", CStr(SentSettings.LoadBPsonStartup))
            ApplicationSettingsList(20) = New Setting("LoadESISystemCostIndiciesDataonStartup", CStr(SentSettings.LoadESISystemCostIndiciesDataonStartup))
            ApplicationSettingsList(21) = New Setting("LoadESIMarketDataonStartup", CStr(SentSettings.LoadESIMarketDataonStartup))
            ApplicationSettingsList(22) = New Setting("SaveBPRelicsDecryptors", CStr(SentSettings.SaveBPRelicsDecryptors))
            ApplicationSettingsList(23) = New Setting("IgnoreSVRThresholdValue", CStr(SentSettings.IgnoreSVRThresholdValue))
            ApplicationSettingsList(24) = New Setting("SVRAveragePriceRegion", CStr(SentSettings.SVRAveragePriceRegion))
            ApplicationSettingsList(25) = New Setting("SVRAveragePriceDuration", CStr(SentSettings.SVRAveragePriceDuration))
            ApplicationSettingsList(26) = New Setting("AutoUpdateSVRonBPTab", CStr(SentSettings.AutoUpdateSVRonBPTab))
            ApplicationSettingsList(27) = New Setting("ProxyAddress", CStr(SentSettings.ProxyAddress))
            ApplicationSettingsList(28) = New Setting("ProxyPort", CStr(SentSettings.ProxyPort))
            ApplicationSettingsList(29) = New Setting("SaveFacilitiesbyChar", CStr(SentSettings.SaveFacilitiesbyChar))
            ApplicationSettingsList(30) = New Setting("LoadBPsbyChar", CStr(SentSettings.LoadBPsbyChar))
            ApplicationSettingsList(31) = New Setting("LoadESIPublicStructuresonStartup", CStr(SentSettings.LoadESIPublicStructuresonStartup))
            ApplicationSettingsList(32) = New Setting("DisableGATracking", CStr(SentSettings.DisableGATracking))
            ApplicationSettingsList(33) = New Setting("AlphaAccount", CStr(SentSettings.AlphaAccount))
            ApplicationSettingsList(34) = New Setting("UseActiveSkillLevels", CStr(SentSettings.UseActiveSkillLevels))
            ApplicationSettingsList(35) = New Setting("SupressESIStatusMessages", CStr(SentSettings.SupressESIStatusMessages))
            ApplicationSettingsList(36) = New Setting("LoadMaxAlphaSkills", CStr(SentSettings.LoadMaxAlphaSkills))
            ApplicationSettingsList(37) = New Setting("ShareSavedFacilities", CStr(SentSettings.ShareSavedFacilities))

            Call WriteSettingsToFile(SettingsFolder, AppSettingsFileName, ApplicationSettingsList, AppSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Application Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the application settings
    Public Function GetApplicationSettings() As ApplicationSettings
        Return ApplicationSettings
    End Function

#End Region

#Region "Shopping List Settings"

    ' Loads the shnopping list settings from XML setting file
    Public Function LoadShoppingListSettings() As ShoppingListSettings
        Dim TempSettings As ShoppingListSettings = Nothing

        Try
            If FileExists(SettingsFolder, ShoppingListSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .DataExportFormat = CStr(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeString, ShoppingListSettingsFileName, "DataExportFormat", DefaultDataExportFormat))
                    .AlwaysonTop = CBool(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "AlwaysonTop", DefaultAlwaysonTop))
                    .UpdateAssetsWhenUsed = CBool(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "UpdateAssetsWhenUsed", DefaultUpdateAssetsWhenUsed))
                    .Fees = CBool(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "Fees", DefaultFees))
                    .CalcBuyBuyOrder = CInt(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeInteger, ShoppingListSettingsFileName, "CalcBuyBuyOrder", DefaultCalcBuyBuyOrder))
                    .Usage = CBool(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "Usage", DefaultUsage))
                    .ReloadBPsFromFile = CBool(GetSettingValue(SettingsFolder, ShoppingListSettingsFileName, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "ReloadBPsFromFile", DefaultReloadBPsFromFile))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultShopingListSettings()
            End If
        Catch ex As Exception
            MsgBox("An error occured when loading Shopping List Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultShopingListSettings()
        End Try

        ' Save them locally and then export
        ShoppingListTabSettings = TempSettings

        Return TempSettings

    End Function

    ' Load defaults 
    Public Function SetDefaultShopingListSettings() As ShoppingListSettings
        Dim TempSettings As ShoppingListSettings = Nothing

        ' Load defaults 
        TempSettings.DataExportFormat = DefaultDataExportFormat
        TempSettings.AlwaysonTop = DefaultAlwaysonTop
        TempSettings.UpdateAssetsWhenUsed = DefaultUpdateAssetsWhenUsed
        TempSettings.UpdateAssetsWhenUsed = DefaultUpdateAssetsWhenUsed
        TempSettings.Fees = DefaultFees
        TempSettings.CalcBuyBuyOrder = DefaultCalcBuyBuyOrder
        TempSettings.Usage = DefaultUsage
        TempSettings.ReloadBPsFromFile = DefaultReloadBPsFromFile

        ShoppingListTabSettings = TempSettings

        Return TempSettings

    End Function

    ' Saves the Shopping List Settings to XML
    Public Sub SaveShoppingListSettings(SentSettings As ShoppingListSettings)
        Dim ShoppingListSettingsList(6) As Setting

        Try
            ShoppingListSettingsList(0) = New Setting("DataExportFormat", CStr(SentSettings.DataExportFormat))
            ShoppingListSettingsList(1) = New Setting("AlwaysonTop", CStr(SentSettings.AlwaysonTop))
            ShoppingListSettingsList(2) = New Setting("UpdateAssetsWhenUsed", CStr(SentSettings.UpdateAssetsWhenUsed))
            ShoppingListSettingsList(3) = New Setting("Fees", CStr(SentSettings.Fees))
            ShoppingListSettingsList(4) = New Setting("CalcBuyBuyOrder", CStr(SentSettings.CalcBuyBuyOrder))
            ShoppingListSettingsList(5) = New Setting("Usage", CStr(SentSettings.Usage))
            ShoppingListSettingsList(6) = New Setting("ReloadBPsFromFile", CStr(SentSettings.ReloadBPsFromFile))

            Call WriteSettingsToFile(SettingsFolder, ShoppingListSettingsFileName, ShoppingListSettingsList, ShoppingListSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Shopping List Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the Shopping List Settings
    Public Function GetShoppingListSettings() As ShoppingListSettings
        Return ShoppingListTabSettings
    End Function

#End Region

#Region "BP Tab Settings"

    ' Loads the tab settings
    Public Function LoadBPSettings() As BPTabSettings
        Dim TempSettings As BPTabSettings = Nothing

        Try
            If FileExists(SettingsFolder, BPSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .BlueprintTypeSelection = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "BlueprintTypeSelection", DefaultBPSelectionType))
                    .Tech1Check = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech1Check", DefaultBPTechChecks))
                    .Tech2Check = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech2Check", DefaultBPTechChecks))
                    .Tech3Check = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech3Check", DefaultBPTechChecks))
                    .TechStorylineCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "TechStorylineCheck", DefaultBPTechChecks))
                    .TechFactionCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "TechFactionCheck", DefaultBPTechChecks))
                    .TechPirateCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "TechPirateCheck", DefaultBPTechChecks))
                    .IncludeUsage = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeUsage", DefaultBPIncludeUsage))
                    .IncludeTaxes = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeTaxes", DefaultBPIncludeTaxes))
                    .PricePerUnit = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "PricePerUnit", DefaultBPPricePerUnit))
                    .IncludeInventionCost = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeInventionCost", DefaultBPIncludeInventionCost))
                    .IncludeInventionTime = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeInventionTime", DefaultBPIncludeInventionTime))
                    .IncludeCopyCost = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeCopyCost", DefaultBPIncludecopyCost))
                    .IncludeCopyTime = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeCopyTime", DefaultBPIncludeCopyTime))
                    .IncludeT3Cost = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeT3Cost", DefaultBPIncludeT3Cost))
                    .IncludeT3Time = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeT3Time", DefaultBPIncludeT3Time))
                    .ProductionLines = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "ProductionLines", DefaultBPProductionLines))
                    .LaboratoryLines = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "LaboratoryLines", DefaultBPLaboratoryLines))
                    .T3Lines = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "RELines", DefaultBPRELines))
                    .SmallCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "SmallCheck", DefaultSizeChecks))
                    .MediumCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "MediumCheck", DefaultSizeChecks))
                    .LargeCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "LargeCheck", DefaultSizeChecks))
                    .XLCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "XLCheck", DefaultSizeChecks))
                    .IncludeFees = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "IncludeFees", DefaultBPIncludeFees))
                    .BrokerFeeRate = CDbl(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeDouble, BPSettingsFileName, "BrokerFeeRate", DefaultBPBrokerFeeRate))
                    .RelicType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "RelicType", DefaultBPRelicType))
                    .T2DecryptorType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "T2DecryptorType", DefaultBPT2DecryptorType))
                    .T3DecryptorType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "T3DecryptorType", DefaultBPT3DecryptorType))
                    .IgnoreInvention = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreInvention", DefaultBPIgnoreInvention))
                    .IgnoreMinerals = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreMinerals", DefaultBPIgnoreMinerals))
                    .IgnoreT1Item = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreT1Item", DefaultBPIgnoreT1Item))
                    .IncludeIgnoredBPs = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeIgnoredBPs", DefaultBPIncludeIgnoredBPs))
                    .ExporttoShoppingListType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "ExporttoShoppingListType", DefaultBPShoppingListExportType))
                    .RawColumnSort = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "RawColumnSort", DefaultBPRawColumnSort))
                    .RawColumnSortType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "RawColumnSortType", DefaultBPRawColumnSortType))
                    .CompColumnSort = CInt(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeInteger, BPSettingsFileName, "CompColumnSort", DefaultBPCompColumnSort))
                    .CompColumnSortType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "CompColumnSortType", DefaultBPCompColumnSortType))
                    .RawProfitType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "RawProfitType", DefaultBPRawProfitType))
                    .CompProfitType = CStr(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "CompProfitType", DefaultBPCompProfitType))
                    .CompressedOre = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "CompressedOre", DefaultBPCompressedOre))
                    .SimpleCopyCheck = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "SimpleCopyCheck", DefaultBPSimpleCopyCheck))
                    .NPCBPOs = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "NPCBPOs", DefaultBPNPCBPOs))
                    .SellExcessBuildItems = CBool(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeBoolean, BPSettingsFileName, "SellExcessBuildItems", DefaultBPSellExcessItems))
                    .BuildT2T3Materials = CType(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeString, BPSettingsFileName, "BuildT2T3Materials", DefaultBuiltMatsType), BuildMatType)
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultBPSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading BP Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultBPSettings()
        End Try

        ' Save them locally and then export
        BPSettings = TempSettings

        Return TempSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveBPSettings(SentSettings As BPTabSettings)
        Dim BPSettingsList(43) As Setting

        Try
            BPSettingsList(0) = New Setting("BlueprintTypeSelection", CStr(SentSettings.BlueprintTypeSelection))
            BPSettingsList(1) = New Setting("Tech1Check", CStr(SentSettings.Tech1Check))
            BPSettingsList(2) = New Setting("Tech2Check", CStr(SentSettings.Tech2Check))
            BPSettingsList(3) = New Setting("Tech3Check", CStr(SentSettings.Tech3Check))
            BPSettingsList(4) = New Setting("TechStorylineCheck", CStr(SentSettings.TechStorylineCheck))
            BPSettingsList(5) = New Setting("TechFactionCheck", CStr(SentSettings.TechFactionCheck))
            BPSettingsList(6) = New Setting("TechPirateCheck", CStr(SentSettings.TechPirateCheck))
            BPSettingsList(7) = New Setting("IncludeUsage", CStr(SentSettings.IncludeUsage))
            BPSettingsList(8) = New Setting("IncludeTaxes", CStr(SentSettings.IncludeTaxes))
            BPSettingsList(9) = New Setting("PricePerUnit", CStr(SentSettings.PricePerUnit))
            BPSettingsList(10) = New Setting("ProductionLines", CStr(SentSettings.ProductionLines))
            BPSettingsList(11) = New Setting("LaboratoryLines", CStr(SentSettings.LaboratoryLines))
            BPSettingsList(12) = New Setting("RELines", CStr(SentSettings.T3Lines))
            BPSettingsList(13) = New Setting("SmallCheck", CStr(SentSettings.SmallCheck))
            BPSettingsList(14) = New Setting("MediumCheck", CStr(SentSettings.MediumCheck))
            BPSettingsList(15) = New Setting("LargeCheck", CStr(SentSettings.LargeCheck))
            BPSettingsList(16) = New Setting("XLCheck", CStr(SentSettings.XLCheck))
            BPSettingsList(17) = New Setting("IncludeFees", CStr(SentSettings.IncludeFees))

            BPSettingsList(18) = New Setting("IncludeInventionCost", CStr(SentSettings.IncludeInventionCost))
            BPSettingsList(19) = New Setting("IncludeInventionTime", CStr(SentSettings.IncludeInventionTime))
            BPSettingsList(20) = New Setting("IncludeCopyCost", CStr(SentSettings.IncludeCopyCost))
            BPSettingsList(21) = New Setting("IncludeCopyTime", CStr(SentSettings.IncludeCopyTime))
            BPSettingsList(22) = New Setting("IncludeT3Cost", CStr(SentSettings.IncludeT3Cost))
            BPSettingsList(23) = New Setting("IncludeT3Time", CStr(SentSettings.IncludeT3Time))
            BPSettingsList(24) = New Setting("RelicType", CStr(SentSettings.RelicType))
            BPSettingsList(25) = New Setting("T2DecryptorType", CStr(SentSettings.T2DecryptorType))

            BPSettingsList(26) = New Setting("IgnoreInvention", CStr(SentSettings.IgnoreInvention))
            BPSettingsList(27) = New Setting("IgnoreMinerals", CStr(SentSettings.IgnoreMinerals))
            BPSettingsList(28) = New Setting("IgnoreT1Item", CStr(SentSettings.IgnoreT1Item))

            BPSettingsList(29) = New Setting("IncludeIgnoredBPs", CStr(SentSettings.IncludeIgnoredBPs))
            BPSettingsList(30) = New Setting("T3DecryptorType", CStr(SentSettings.T3DecryptorType))
            BPSettingsList(31) = New Setting("ExporttoShoppingListType", CStr(SentSettings.ExporttoShoppingListType))

            BPSettingsList(32) = New Setting("RawColumnSort", CStr(SentSettings.RawColumnSort))
            BPSettingsList(33) = New Setting("RawColumnSortType", CStr(SentSettings.RawColumnSortType))
            BPSettingsList(34) = New Setting("CompColumnSort", CStr(SentSettings.CompColumnSort))
            BPSettingsList(35) = New Setting("CompColumnSortType", CStr(SentSettings.CompColumnSortType))

            BPSettingsList(36) = New Setting("RawProfitType", CStr(SentSettings.RawProfitType))
            BPSettingsList(37) = New Setting("CompProfitType", CStr(SentSettings.CompProfitType))
            BPSettingsList(38) = New Setting("CompressedOre", CStr(SentSettings.CompressedOre))

            BPSettingsList(39) = New Setting("SimpleCopyCheck", CStr(SentSettings.SimpleCopyCheck))

            BPSettingsList(40) = New Setting("NPCBPOs", CStr(SentSettings.NPCBPOs))
            BPSettingsList(41) = New Setting("SellExcessBuildItems", CStr(SentSettings.SellExcessBuildItems))
            BPSettingsList(42) = New Setting("BrokerFeeRate", CStr(SentSettings.BrokerFeeRate))

            BPSettingsList(43) = New Setting("BuildT2T3Materials", CStr(SentSettings.BuildT2T3Materials))

            Call WriteSettingsToFile(SettingsFolder, BPSettingsFileName, BPSettingsList, BPSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving BP Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Loads the defaults
    Public Function SetDefaultBPSettings() As BPTabSettings
        Dim LocalSettings As BPTabSettings

        With LocalSettings
            .BlueprintTypeSelection = DefaultBPSelectionType
            .Tech1Check = DefaultBPTechChecks
            .Tech2Check = DefaultBPTechChecks
            .Tech3Check = DefaultBPTechChecks
            .TechStorylineCheck = DefaultBPTechChecks
            .TechFactionCheck = DefaultBPTechChecks
            .TechPirateCheck = DefaultBPTechChecks
            .IncludeUsage = DefaultBPIncludeUsage
            .IncludeTaxes = DefaultBPIncludeTaxes
            .IncludeFees = DefaultIncludeBrokerFees
            .BrokerFeeRate = DefaultBPBrokerFeeRate
            .PricePerUnit = DefaultBPPricePerUnit
            .ProductionLines = DefaultBPProductionLines
            .LaboratoryLines = DefaultBPLaboratoryLines
            .T3Lines = DefaultBPRELines
            .SmallCheck = DefaultSizeChecks
            .MediumCheck = DefaultSizeChecks
            .LargeCheck = DefaultSizeChecks
            .XLCheck = DefaultSizeChecks
            .SimpleCopyCheck = DefaultBPSimpleCopyCheck
            .NPCBPOs = DefaultBPNPCBPOs
            .SellExcessBuildItems = DefaultBPSellExcessItems

            .IncludeInventionCost = DefaultBPIncludeInventionCost
            .IncludeInventionTime = DefaultBPIncludeInventionTime
            .IncludeCopyCost = DefaultBPIncludecopyCost
            .IncludeCopyTime = DefaultBPIncludeCopyTime
            .IncludeT3Cost = DefaultBPIncludeT3Cost
            .IncludeT3Time = DefaultBPIncludeT3Time

            .RelicType = DefaultBPRelicType
            .T2DecryptorType = DefaultBPT2DecryptorType
            .T3DecryptorType = DefaultBPT3DecryptorType

            .IgnoreInvention = DefaultBPIgnoreInvention
            .IgnoreMinerals = DefaultBPIgnoreMinerals
            .IgnoreT1Item = DefaultBPIgnoreT1Item

            .IncludeIgnoredBPs = DefaultBPIncludeIgnoredBPs

            .ExporttoShoppingListType = DefaultBPShoppingListExportType

            .CompColumnSort = DefaultBPCompColumnSort
            .CompColumnSortType = DefaultBPCompColumnSortType
            .RawColumnSort = DefaultBPRawColumnSort
            .RawColumnSortType = DefaultBPRawColumnSortType

            .RawProfitType = DefaultBPRawProfitType
            .CompProfitType = DefaultBPCompProfitType

            .CompressedOre = DefaultBPCompressedOre
            .SellExcessBuildItems = DefaultBPSellExcessItems
            .BuildT2T3Materials = CType(DefaultBuiltMatsType, BuildMatType)
        End With

        ' Save locally
        BPSettings = LocalSettings

        Return LocalSettings

    End Function

    ' Returns the tab settings
    Public Function GetBPSettings() As BPTabSettings
        Return BPSettings
    End Function

#End Region

#Region "Update Price Tab Settings"

    ' Loads the tab settings
    Public Function LoadUpdatePricesSettings() As UpdatePriceTabSettings
        Dim TempSettings As UpdatePriceTabSettings = Nothing

        Try
            If FileExists(SettingsFolder, UpdatePricesFileName) Then

                'Get the settings
                With TempSettings
                    .AllRawMats = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AllRawMats", DefaultPriceChecks))
                    .Minerals = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Minerals", DefaultPriceChecks))
                    .IceProducts = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "IceProducts", DefaultPriceChecks))
                    .Gas = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Gas", DefaultPriceChecks))
                    .BPCs = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "BPCs", DefaultPriceChecks))
                    .Misc = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Misc", DefaultPriceChecks))
                    .AncientRelics = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AncientRelics", DefaultPriceChecks))
                    .AncientSalvage = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AncientSalvage", DefaultPriceChecks))
                    .Salvage = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Salvage", DefaultPriceChecks))
                    .StationComponents = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "StationComponents", DefaultPriceChecks))
                    .Planetary = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Planetary", DefaultPriceChecks))
                    .Datacores = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Datacores", DefaultPriceChecks))
                    .Decryptors = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Decryptors", DefaultPriceChecks))
                    .Deployables = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Deployables", DefaultPriceChecks))
                    .Celestials = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Celestials", DefaultPriceChecks))
                    .Deployables = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Deployables", DefaultPriceChecks))
                    .Implants = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Implants", DefaultPriceChecks))
                    .RawMats = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "RawMats", DefaultPriceChecks))
                    .ProcessedMats = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "ProcessedMats", DefaultPriceChecks))
                    .AdvancedMats = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AdvancedMats", DefaultPriceChecks))
                    .MatsandCompounds = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "MatsandCompounds", DefaultPriceChecks))
                    .DroneComponents = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "DroneComponents", DefaultPriceChecks))
                    .BoosterMats = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "BoosterMats", DefaultPriceChecks))
                    .Polymers = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Polymers", DefaultPriceChecks))
                    .Asteroids = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Asteroids", DefaultPriceChecks))
                    .AllManufacturedItems = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AllManufacturedItems", DefaultPriceChecks))
                    .Ships = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Ships", DefaultPriceChecks))
                    .Modules = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Modules", DefaultPriceChecks))
                    .Drones = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Drones", DefaultPriceChecks))
                    .Boosters = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Boosters", DefaultPriceChecks))
                    .Rigs = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Rigs", DefaultPriceChecks))
                    .Charges = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Charges", DefaultPriceChecks))
                    .Subsystems = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Subsystems", DefaultPriceChecks))
                    .Structures = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Structures", DefaultPriceChecks))
                    .Tools = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Tools", DefaultPriceChecks))
                    .CapT2Components = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "CapT2Components", DefaultPriceChecks))
                    .CapitalComponents = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "CapitalComponents", DefaultPriceChecks))
                    .Components = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Components", DefaultPriceChecks))
                    .Hybrid = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Hybrid", DefaultPriceChecks))
                    .StructureComponents = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "StructureComponents", DefaultPriceChecks))
                    .FuelBlocks = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "FuelBlocks", DefaultPriceChecks))
                    .T1 = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "T1", DefaultPriceChecks))
                    .T2 = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "T2", DefaultPriceChecks))
                    .T3 = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "T3", DefaultPriceChecks))
                    .Faction = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Faction", DefaultPriceChecks))
                    .Pirate = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Pirate", DefaultPriceChecks))
                    .Storyline = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "Storyline", DefaultPriceChecks))
                    .StructureModules = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "StructureModules", DefaultPriceChecks))
                    .AbyssalMaterials = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "AbyssalMaterials", DefaultPriceChecks))

                    Dim TempRegions As String = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "SelectedRegions", DefaultPriceRegion))
                    Dim RegionList As New List(Of String)
                    Dim RegionCount As Integer

                    If TempRegions <> "0" Then
                        RegionCount = Regex.Matches(TempRegions, Regex.Escape(",")).Count + 1 ' Add one for last item + 1 ' Add one for last item
                    End If

                    Dim ReaderStartPosition As Integer = 0
                    Dim CommaLoc As Integer

                    For i = 0 To RegionCount - 1
                        CommaLoc = InStr(TempRegions.Substring(ReaderStartPosition), ",")
                        If CommaLoc <> 0 Then
                            RegionList.Add(TempRegions.Substring(ReaderStartPosition, CommaLoc - 1))
                        Else ' At the end
                            RegionList.Add(TempRegions.Substring(ReaderStartPosition))
                        End If
                        ReaderStartPosition = ReaderStartPosition + CommaLoc
                    Next

                    .SelectedRegions = RegionList
                    .SelectedSystem = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "SelectedSystem", DefaultPriceSystem))
                    .ItemsCombo = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "ItemsCombo", DefaultPriceItemsCombo))
                    .RawMatsCombo = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "RawMatsCombo", DefaultPriceRawMatsCombo))

                    .RawPriceModifier = CDbl(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeDouble, UpdatePricesFileName, "RawPriceModifier", DefaultRawPriceModifier))
                    .ItemsPriceModifier = CDbl(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeDouble, UpdatePricesFileName, "ItemsPriceModifier", DefaultItemsPriceModifier))

                    .UseESIData = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "UseESIData", DefaultUseESIData))
                    .UsePriceProfile = CBool(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeBoolean, UpdatePricesFileName, "UsePriceProfile", DefaultUsePriceProfile))

                    .ColumnSort = CInt(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeInteger, UpdatePricesFileName, "ColumnSort", DefaultUPColumnSort))
                    .ColumnSortType = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "ColumnSortType", DefaultUPColumnSortType))

                    .PPRawPriceType = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPRawPriceType", DefaultPPRawPriceType))
                    .PPRawRegion = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPRawRegion", DefaultPPRawRegion))
                    .PPRawSystem = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPRawSystem", DefaultPPRawSystem))
                    .PPRawPriceMod = CDbl(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeDouble, UpdatePricesFileName, "PPRawPriceMod", DefaultPPRawPriceMod))

                    .PPItemsPriceType = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsPriceType", DefaultPPItemsPriceType))
                    .PPItemsRegion = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsRegion", DefaultPPItemsRegion))
                    .PPItemsSystem = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsSystem", DefaultPPItemsSystem))
                    .PPItemsPriceMod = CDbl(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeDouble, UpdatePricesFileName, "PPItemsPriceMod", DefaultPPItemsPriceMod))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultUpdatePriceSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Update Prices Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultUpdatePriceSettings()
        End Try

        ' Save them locally and then export
        UpdatePricesSettings = TempSettings

        Return TempSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveUpdatePricesSettings(PriceSettings As UpdatePriceTabSettings)
        Dim UpdatePricesSettingsList(65) As Setting

        Try
            UpdatePricesSettingsList(0) = New Setting("AllRawMats", CStr(PriceSettings.AllRawMats))
            UpdatePricesSettingsList(1) = New Setting("Minerals", CStr(PriceSettings.Minerals))
            UpdatePricesSettingsList(2) = New Setting("IceProducts", CStr(PriceSettings.IceProducts))
            UpdatePricesSettingsList(3) = New Setting("Gas", CStr(PriceSettings.Gas))
            UpdatePricesSettingsList(4) = New Setting("AncientRelics", CStr(PriceSettings.AncientRelics))
            UpdatePricesSettingsList(5) = New Setting("AncientSalvage", CStr(PriceSettings.AncientSalvage))
            UpdatePricesSettingsList(6) = New Setting("Salvage", CStr(PriceSettings.Salvage))
            UpdatePricesSettingsList(7) = New Setting("StationComponents", CStr(PriceSettings.StationComponents))
            UpdatePricesSettingsList(8) = New Setting("Planetary", CStr(PriceSettings.Planetary))
            UpdatePricesSettingsList(9) = New Setting("Datacores", CStr(PriceSettings.Datacores))
            UpdatePricesSettingsList(10) = New Setting("Decryptors", CStr(PriceSettings.Decryptors))
            UpdatePricesSettingsList(11) = New Setting("RawMats", CStr(PriceSettings.RawMats))
            UpdatePricesSettingsList(12) = New Setting("ProcessedMats", CStr(PriceSettings.ProcessedMats))
            UpdatePricesSettingsList(13) = New Setting("AdvancedMats", CStr(PriceSettings.AdvancedMats))
            UpdatePricesSettingsList(14) = New Setting("MatsandCompounds", CStr(PriceSettings.MatsandCompounds))
            UpdatePricesSettingsList(15) = New Setting("DroneComponents", CStr(PriceSettings.DroneComponents))
            UpdatePricesSettingsList(16) = New Setting("BoosterMats", CStr(PriceSettings.BoosterMats))
            UpdatePricesSettingsList(17) = New Setting("Polymers", CStr(PriceSettings.Polymers))
            UpdatePricesSettingsList(18) = New Setting("AllManufacturedItems", CStr(PriceSettings.AllManufacturedItems))
            UpdatePricesSettingsList(19) = New Setting("Ships", CStr(PriceSettings.Ships))
            UpdatePricesSettingsList(20) = New Setting("Modules", CStr(PriceSettings.Modules))
            UpdatePricesSettingsList(21) = New Setting("Drones", CStr(PriceSettings.Drones))
            UpdatePricesSettingsList(22) = New Setting("Boosters", CStr(PriceSettings.Boosters))
            UpdatePricesSettingsList(23) = New Setting("Rigs", CStr(PriceSettings.Rigs))
            UpdatePricesSettingsList(24) = New Setting("Charges", CStr(PriceSettings.Charges))
            UpdatePricesSettingsList(25) = New Setting("Subsystems", CStr(PriceSettings.Subsystems))
            UpdatePricesSettingsList(26) = New Setting("Structures", CStr(PriceSettings.Structures))
            UpdatePricesSettingsList(27) = New Setting("Tools", CStr(PriceSettings.Tools))
            UpdatePricesSettingsList(28) = New Setting("CapT2Components", CStr(PriceSettings.CapT2Components))
            UpdatePricesSettingsList(29) = New Setting("CapitalComponents", CStr(PriceSettings.CapitalComponents))
            UpdatePricesSettingsList(30) = New Setting("Components", CStr(PriceSettings.Components))
            UpdatePricesSettingsList(31) = New Setting("Hybrid", CStr(PriceSettings.Hybrid))
            UpdatePricesSettingsList(32) = New Setting("FuelBlocks", CStr(PriceSettings.FuelBlocks))
            UpdatePricesSettingsList(33) = New Setting("T1", CStr(PriceSettings.T1))
            UpdatePricesSettingsList(34) = New Setting("T2", CStr(PriceSettings.T2))
            UpdatePricesSettingsList(35) = New Setting("T3", CStr(PriceSettings.T3))
            UpdatePricesSettingsList(36) = New Setting("Faction", CStr(PriceSettings.Faction))
            UpdatePricesSettingsList(37) = New Setting("Pirate", CStr(PriceSettings.Pirate))
            UpdatePricesSettingsList(38) = New Setting("Storyline", CStr(PriceSettings.Storyline))
            Dim RegionList As String = ""
            If Not IsNothing(PriceSettings.SelectedRegions) Then
                For i = 0 To PriceSettings.SelectedRegions.Count - 1
                    RegionList = RegionList & PriceSettings.SelectedRegions(i) & ","
                Next
                If RegionList <> "" Then
                    ' Strip last comma
                    RegionList = RegionList.Substring(0, Len(RegionList) - 1)
                End If
            Else
                RegionList = "0"
            End If
            UpdatePricesSettingsList(39) = New Setting("SelectedRegions", RegionList)
            UpdatePricesSettingsList(40) = New Setting("SelectedSystem", CStr(PriceSettings.SelectedSystem))
            UpdatePricesSettingsList(41) = New Setting("ItemsCombo", CStr(PriceSettings.ItemsCombo))
            UpdatePricesSettingsList(42) = New Setting("RawMatsCombo", CStr(PriceSettings.RawMatsCombo))

            UpdatePricesSettingsList(43) = New Setting("Asteroids", CStr(PriceSettings.Asteroids))
            UpdatePricesSettingsList(44) = New Setting("Misc", CStr(PriceSettings.Misc))

            UpdatePricesSettingsList(45) = New Setting("Deployables", CStr(PriceSettings.Deployables))
            UpdatePricesSettingsList(46) = New Setting("Celestials", CStr(PriceSettings.Celestials))
            UpdatePricesSettingsList(47) = New Setting("Implants", CStr(PriceSettings.Implants))

            UpdatePricesSettingsList(48) = New Setting("BPCs", CStr(PriceSettings.BPCs))

            UpdatePricesSettingsList(49) = New Setting("ColumnSort", CStr(PriceSettings.ColumnSort))
            UpdatePricesSettingsList(50) = New Setting("ColumnSortType", CStr(PriceSettings.ColumnSortType))

            UpdatePricesSettingsList(51) = New Setting("RawPriceModifier", CStr(PriceSettings.RawPriceModifier))
            UpdatePricesSettingsList(52) = New Setting("ItemsPriceModifier", CStr(PriceSettings.ItemsPriceModifier))
            UpdatePricesSettingsList(53) = New Setting("UseESIData", CStr(PriceSettings.UseESIData))
            UpdatePricesSettingsList(54) = New Setting("UsePriceProfile", CStr(PriceSettings.UsePriceProfile))

            UpdatePricesSettingsList(55) = New Setting("PPRawPriceType", CStr(PriceSettings.PPRawPriceType))
            UpdatePricesSettingsList(56) = New Setting("PPRawRegion", CStr(PriceSettings.PPRawRegion))
            UpdatePricesSettingsList(57) = New Setting("PPRawSystem", CStr(PriceSettings.PPRawSystem))
            UpdatePricesSettingsList(58) = New Setting("PPRawPriceMod", CStr(PriceSettings.PPRawPriceMod))

            UpdatePricesSettingsList(59) = New Setting("PPItemsPriceType", CStr(PriceSettings.PPItemsPriceType))
            UpdatePricesSettingsList(60) = New Setting("PPItemsRegion", CStr(PriceSettings.PPItemsRegion))
            UpdatePricesSettingsList(61) = New Setting("PPItemsSystem", CStr(PriceSettings.PPItemsSystem))
            UpdatePricesSettingsList(62) = New Setting("PPItemsPriceMod", CStr(PriceSettings.PPItemsPriceMod))

            UpdatePricesSettingsList(63) = New Setting("StructureModules", CStr(PriceSettings.StructureModules))
            UpdatePricesSettingsList(64) = New Setting("AbyssalMaterials", CStr(PriceSettings.AbyssalMaterials))

            UpdatePricesSettingsList(65) = New Setting("StructureComponents", CStr(PriceSettings.StructureComponents))

            Call WriteSettingsToFile(SettingsFolder, UpdatePricesFileName, UpdatePricesSettingsList, UpdatePricesFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Update Prices Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    Public Function SetDefaultUpdatePriceSettings() As UpdatePriceTabSettings
        Dim LocalSettings As UpdatePriceTabSettings

        With LocalSettings
            .AllRawMats = DefaultPriceChecks
            .Minerals = DefaultPriceChecks
            .IceProducts = DefaultPriceChecks
            .Gas = DefaultPriceChecks
            .AbyssalMaterials = DefaultPriceChecks
            .BPCs = DefaultPriceChecks
            .Misc = DefaultPriceChecks
            .AncientRelics = DefaultPriceChecks
            .AncientSalvage = DefaultPriceChecks
            .Salvage = DefaultPriceChecks
            .StationComponents = DefaultPriceChecks
            .Planetary = DefaultPriceChecks
            .Datacores = DefaultPriceChecks
            .Decryptors = DefaultPriceChecks
            .RawMats = DefaultPriceChecks
            .ProcessedMats = DefaultPriceChecks
            .AdvancedMats = DefaultPriceChecks
            .MatsandCompounds = DefaultPriceChecks
            .DroneComponents = DefaultPriceChecks
            .BoosterMats = DefaultPriceChecks
            .Polymers = DefaultPriceChecks
            .Asteroids = DefaultPriceChecks
            .AllManufacturedItems = DefaultPriceChecks
            .Ships = DefaultPriceChecks
            .Modules = DefaultPriceChecks
            .Drones = DefaultPriceChecks
            .Boosters = DefaultPriceChecks
            .Rigs = DefaultPriceChecks
            .Charges = DefaultPriceChecks
            .Subsystems = DefaultPriceChecks
            .Structures = DefaultPriceChecks
            .Tools = DefaultPriceChecks
            .CapT2Components = DefaultPriceChecks
            .CapitalComponents = DefaultPriceChecks
            .Components = DefaultPriceChecks
            .Hybrid = DefaultPriceChecks
            .StructureComponents = DefaultPriceChecks
            .FuelBlocks = DefaultPriceChecks
            .Implants = DefaultPriceChecks
            .Celestials = DefaultPriceChecks
            .Deployables = DefaultPriceChecks
            .T1 = DefaultPriceChecks
            .T2 = DefaultPriceChecks
            .T3 = DefaultPriceChecks
            .Faction = DefaultPriceChecks
            .Pirate = DefaultPriceChecks
            .Storyline = DefaultPriceChecks
            .SelectedRegions = Nothing
            .SelectedSystem = DefaultPriceSystem
            .ItemsCombo = DefaultPriceItemsCombo
            .RawMatsCombo = DefaultPriceRawMatsCombo
            .ColumnSort = DefaultUPColumnSort
            .ColumnSortType = DefaultUPColumnSortType
            .RawPriceModifier = DefaultRawPriceModifier
            .ItemsPriceModifier = DefaultItemsPriceModifier
            .UseESIData = DefaultUseESIData
            .UsePriceProfile = DefaultUsePriceProfile
            .StructureModules = DefaultPriceChecks

            .PPItemsPriceType = DefaultPPItemsPriceType
            .PPItemsRegion = DefaultPPItemsRegion
            .PPItemsSystem = DefaultPPItemsSystem
            .PPItemsPriceMod = DefaultPPItemsPriceMod
            .PPRawPriceType = DefaultPPRawPriceType
            .PPRawRegion = DefaultPPRawRegion
            .PPRawSystem = DefaultPPRawSystem
            .PPRawPriceMod = DefaultPPRawPriceMod

        End With

        ' Save locally
        UpdatePricesSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Returns the tab settings
    Public Function GetUpdatePricesSettings() As UpdatePriceTabSettings
        Return UpdatePricesSettings
    End Function

#End Region

#Region "Manufacturing Tab Settings"

    ' Loads the tab settings
    Public Function LoadManufacturingSettings() As ManufacturingTabSettings
        Dim TempSettings As ManufacturingTabSettings = Nothing

        Try
            If FileExists(SettingsFolder, ManufacturingSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .BlueprintType = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "BlueprintType", DefaultBlueprintType))
                    .CheckTech1 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech1", DefaultCheckTech1))
                    .CheckTech2 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech2", DefaultCheckTech2))
                    .CheckTech3 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech3", DefaultCheckTech3))
                    .CheckTechStoryline = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechStoryline", DefaultCheckTechStoryline))
                    .CheckTechNavy = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechNavy", DefaultCheckTechNavy))
                    .CheckTechPirate = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechPirate", DefaultCheckTechPirate))
                    .ItemTypeFilter = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "ItemTypeFilter", DefaultItemTypeFilter))
                    .TextItemFilter = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "TextItemFilter", DefaultTextItemFilter))
                    .CheckBPTypeShips = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeShips", DefaultCheckBPTypeShips))
                    .CheckBPTypeDrones = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeDrones", DefaultCheckBPTypeDrones))
                    .CheckBPTypeComponents = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeComponents", DefaultCheckBPTypeComponents))
                    .CheckBPTypeStructures = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStructures", DefaultCheckBPTypeStructures))
                    .CheckBPTypeMisc = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeMisc", DefaultCheckBPTypeTools))
                    .CheckBPTypeNPCBPOs = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeNPCBPOs", DefaultCheckBPTypeNPCBPOs))
                    .CheckBPTypeModules = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeModules", DefaultCheckBPTypeModules))
                    .CheckBPTypeAmmoCharges = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeAmmoCharges", DefaultCheckBPTypeAmmoCharges))
                    .CheckBPTypeRigs = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeRigs", DefaultCheckBPTypeRigs))
                    .CheckBPTypeSubsystems = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeSubsystems", DefaultCheckBPTypeSubsystems))
                    .CheckBPTypeBoosters = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeBoosters", DefaultCheckBPTypeBoosters))
                    .CheckBPTypeDeployables = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeDeployables", DefaultCheckBPTypeDeployables))
                    .CheckBPTypeCelestials = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeCelestials", DefaultCheckBPTypeCelestials))
                    .CheckBPTypeReactions = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeReactions", DefaultCheckBPTypeReactions))
                    .CheckBPTypeStructureModules = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStructureModules", DefaultCheckBPTypeStructureModules))
                    .CheckBPTypeStationParts = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStationParts", DefaultCheckBPTypeStationParts))
                    .CheckDecryptorNone = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorNone", DefaultCheckDecryptorNone))
                    .CheckDecryptorOptimal = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "CheckDecryptorOptimal", DefaultCheckDecryptorOptimal))
                    .CheckDecryptor06 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor06", DefaultCheckDecryptor06))
                    .CheckDecryptor09 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor09", DefaultCheckDecryptor09))
                    .CheckDecryptor10 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor10", DefaultCheckDecryptor10))
                    .CheckDecryptor11 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor11", DefaultCheckDecryptor11))
                    .CheckDecryptor12 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor12", DefaultCheckDecryptor12))
                    .CheckDecryptor15 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor15", DefaultCheckDecryptor15))
                    .CheckDecryptor18 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor18", DefaultCheckDecryptor18))
                    .CheckDecryptor19 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor19", DefaultCheckDecryptor19))
                    .CheckDecryptorUseforT2 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorUseforT2", DefaultCheckDecryptorUseforT2))
                    .CheckDecryptorUseforT3 = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorUseforT3", DefaultCheckDecryptorUseforT3))
                    .CheckIgnoreInvention = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIgnoreInvention", DefaultCheckIgnoreInvention))
                    .CheckRelicWrecked = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicWrecked", DefaultCheckRelicWrecked))
                    .CheckRelicIntact = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicIntact", DefaultCheckRelicIntact))
                    .CheckRelicMalfunction = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicMalfunction", DefaultCheckRelicMalfunction))
                    .CheckOnlyBuild = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckOnlyBuild", DefaultCheckOnlyBuild))
                    .CheckOnlyInvent = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckOnlyInvent", DefaultCheckOnlyInvent))
                    .CheckIncludeTaxes = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeTaxes", DefaultCheckIncludeTaxes))
                    .CheckIncludeBrokersFees = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "CheckIncludeBrokersFees", DefaultIncludeBrokersFees))
                    .CalcBrokerFeeRate = CDbl(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "CalcBrokerFeeRate", DefaultCalcBrokerFeeRate))
                    .CheckIncludeUsage = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeUsage", DefaultCheckIncludeUsage))
                    .CheckRaceAmarr = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceAmarr", DefaultCheckRaceAmarr))
                    .CheckRaceCaldari = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceCaldari", DefaultCheckRaceCaldari))
                    .CheckRaceGallente = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceGallente", DefaultCheckRaceGallente))
                    .CheckRaceMinmatar = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceMinmatar", DefaultCheckRacePirate))
                    .CheckRacePirate = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRacePirate", DefaultCheckRacePirate))
                    .CheckRaceOther = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceOther", DefaultCheckRaceOther))
                    .PriceCompare = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "PriceCompare", DefaultPriceCompare))
                    .CheckIncludeT2Owned = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeT2Owned", DefaultCheckIncludeT2Owned))
                    .CheckIncludeT3Owned = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeT3Owned", DefaultCheckIncludeT3Owned))
                    .CheckSVRIncludeNull = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSVRIncludeNull", DefaultCheckSVRIncludeNull))
                    .ProductionLines = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ProductionLines", DefaultCalcProductionLines))
                    .LaboratoryLines = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "LaboratoryLines", DefaultCalcLaboratoryLines))
                    .Runs = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "Runs", DefaultCalcRuns))
                    .BPRuns = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "BPRuns", DefaultCalcBPRuns))
                    .CheckSmall = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSmall", DefaultCalcSizeChecks))
                    .CheckMedium = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckMedium", DefaultCalcSizeChecks))
                    .CheckLarge = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckLarge", DefaultCalcSizeChecks))
                    .CheckXL = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckXL", DefaultCalcSizeChecks))
                    .CheckCapitalComponentsFacility = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckCapitalComponentsFacility", DefaultCheckT3Destroyers))
                    .CheckT3DestroyerFacility = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckT3DestroyerFacility", DefaultCheckCapComponents))
                    .CheckAutoCalcNumBPs = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckAutoCalcNumBPs", DefaultCheckAutoCalcNumBPs))
                    .IgnoreInvention = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreInvention", DefaultCalcIgnoreInvention))
                    .IgnoreMinerals = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreMinerals", DefaultCalcIgnoreMinerals))
                    .IgnoreT1Item = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreT1Item", DefaultCalcIgnoreT1Item))
                    .CalcPPU = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CalcPPU", DefaultCalcPPU))
                    .ManufacturingFWUpgradeLevel = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "ManufacturingFWUpgradeLevel", DefaultCalcManufacturingFWLevel))
                    .CopyingFWUpgradeLevel = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "CopyingFWUpgradeLevel", DefaultCalcCopyingFWLevel))
                    .InventionFWUpgradeLevel = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "InventionFWUpgradeLevel", DefaultCalcInventionFWLevel))
                    .ColumnSort = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ColumnSort", DefaultCalcColumnSort))
                    .ColumnSortType = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "ColumnSortType", DefaultCalcColumnType))
                    .Volatility = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "Volatility", DefaultCalcVolatility))
                    .Score = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "Score", DefaultCalcScore))
                    .RiskProfit = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "RiskProfit", DefaultCalcRiskProfit))
                    .RiskIPH = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "RiskIPH", DefaultCalcRiskIPH))
                    .RiskPrice = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "Risk Price", DefaultCalcRiskPrice))
                    .PriceTrend = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "PriceTrend", DefaultCalcPriceTrend))
                    .MinBuildTime = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "MinBuildTime", DefaultCalcMinBuildTime))
                    .MinBuildTimeCheck = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "MinBuildTimeCheck", DefaultCalcMinBuildTimeCheck))
                    .MaxBuildTime = CStr(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "MaxBuildTime", DefaultCalcMaxBuildTime))
                    .MaxBuildTimeCheck = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "MaxBuildTimeCheck", DefaultCalcMaxBuildTimeCheck))
                    .IPHThreshold = CDbl(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "IPHThreshold", DefaultCalcIPHThreshold))
                    .IPHThresholdCheck = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IPHThresholdCheck", DefaultCalcMinBuildTimeCheck))
                    .ProfitThreshold = CDbl(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "ProfitThreshold", DefaultCalcProfitThreshold))
                    .ProfitThresholdCheck = CInt(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ProfitThresholdCheck", DefaultCalcProfitThresholdCheck))
                    .VolumeThreshold = CDbl(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "VolumeThreshold", DefaultCalcVolumeThreshold))
                    .VolumeThresholdCheck = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "VolumeThresholdCheck", DefaultCalcVolumeThresholdCheck))
                    .CheckSellExcessItems = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSellExcessItems", DefaultCalcSellExcessItems))
                    .BuildT2T3Materials = CType(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeString, ManufacturingSettingsFileName, "BuildT2T3Materials", DefaultBuiltMatsType), BuildMatType)
                End With
            Else
                ' Load defaults 
                TempSettings = SetDefaultManufacturingSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Manufacturing Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultManufacturingSettings()
        End Try

        ' Save them locally and then export
        ManufacturingSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultManufacturingSettings() As ManufacturingTabSettings
        Dim LocalSettings As ManufacturingTabSettings

        With LocalSettings
            .BlueprintType = DefaultBlueprintType
            .CheckTech1 = DefaultCheckTech1
            .CheckTech2 = DefaultCheckTech2
            .CheckTech3 = DefaultCheckTech3
            .CheckTechStoryline = DefaultCheckTechStoryline
            .CheckTechNavy = DefaultCheckTechNavy
            .CheckTechPirate = DefaultCheckTechPirate
            .ItemTypeFilter = DefaultItemTypeFilter
            .TextItemFilter = DefaultTextItemFilter
            .CheckBPTypeNPCBPOs = DefaultCheckBPTypeNPCBPOs
            .CheckBPTypeShips = DefaultCheckBPTypeShips
            .CheckBPTypeDrones = DefaultCheckBPTypeDrones
            .CheckBPTypeComponents = DefaultCheckBPTypeComponents
            .CheckBPTypeStructures = DefaultCheckBPTypeStructures
            .CheckBPTypeMisc = DefaultCheckBPTypeTools
            .CheckBPTypeModules = DefaultCheckBPTypeModules
            .CheckBPTypeAmmoCharges = DefaultCheckBPTypeAmmoCharges
            .CheckBPTypeRigs = DefaultCheckBPTypeRigs
            .CheckBPTypeSubsystems = DefaultCheckBPTypeSubsystems
            .CheckBPTypeBoosters = DefaultCheckBPTypeBoosters
            .CheckBPTypeCelestials = DefaultCheckBPTypeCelestials
            .CheckBPTypeStructureModules = DefaultCheckBPTypeStructureModules
            .CheckBPTypeStationParts = DefaultCheckBPTypeStationParts
            .CheckBPTypeDeployables = DefaultCheckBPTypeDeployables
            .CheckBPTypeReactions = DefaultCheckBPTypeReactions
            .CheckDecryptorNone = DefaultCheckDecryptorNone
            .CheckDecryptorOptimal = DefaultCheckDecryptorOptimal
            .CheckDecryptor06 = DefaultCheckDecryptor06
            .CheckDecryptor09 = DefaultCheckDecryptor09
            .CheckDecryptor10 = DefaultCheckDecryptor10
            .CheckDecryptor11 = DefaultCheckDecryptor11
            .CheckDecryptor12 = DefaultCheckDecryptor12
            .CheckDecryptor15 = DefaultCheckDecryptor15
            .CheckDecryptor18 = DefaultCheckDecryptor18
            .CheckDecryptor19 = DefaultCheckDecryptor19
            .CheckDecryptorUseforT2 = DefaultCheckDecryptorUseforT2
            .CheckDecryptorUseforT3 = DefaultCheckDecryptorUseforT3
            .CheckIgnoreInvention = DefaultCheckIgnoreInvention
            .CheckRelicWrecked = DefaultCheckRelicWrecked
            .CheckRelicIntact = DefaultCheckRelicIntact
            .CheckRelicMalfunction = DefaultCheckRelicMalfunction
            .CheckOnlyBuild = DefaultCheckOnlyBuild
            .CheckOnlyInvent = DefaultCheckOnlyInvent
            .CheckIncludeTaxes = DefaultCheckIncludeTaxes
            .CheckIncludeBrokersFees = DefaultIncludeBrokersFees
            .CalcBrokerFeeRate = DefaultCalcBrokerFeeRate
            .CheckIncludeUsage = DefaultCheckIncludeUsage
            .CheckRaceAmarr = DefaultCheckRaceAmarr
            .CheckRaceCaldari = DefaultCheckRaceCaldari
            .CheckRaceGallente = DefaultCheckRaceGallente
            .CheckRaceMinmatar = DefaultCheckRaceMinmatar
            .CheckRacePirate = DefaultCheckRacePirate
            .CheckRaceOther = DefaultCheckRaceOther
            .PriceCompare = DefaultPriceCompare
            .CheckIncludeT2Owned = DefaultCheckIncludeT2Owned
            .CheckIncludeT3Owned = DefaultCheckIncludeT3Owned
            .CheckSVRIncludeNull = DefaultCheckSVRIncludeNull
            .ProductionLines = DefaultCalcProductionLines
            .LaboratoryLines = DefaultCalcLaboratoryLines
            .Runs = DefaultCalcRuns
            .BPRuns = DefaultCalcBPRuns
            .CheckSmall = DefaultCalcSizeChecks
            .CheckMedium = DefaultCalcSizeChecks
            .CheckLarge = DefaultCalcSizeChecks
            .CheckXL = DefaultCalcSizeChecks
            .CheckT3DestroyerFacility = DefaultCheckT3Destroyers
            .CheckCapitalComponentsFacility = DefaultCheckCapComponents
            .CheckAutoCalcNumBPs = DefaultCheckAutoCalcNumBPs
            .IgnoreInvention = DefaultCalcIgnoreInvention
            .IgnoreMinerals = DefaultCalcIgnoreMinerals
            .IgnoreT1Item = DefaultCalcIgnoreT1Item
            .CalcPPU = DefaultCalcPPU
            .CheckSellExcessItems = DefaultBPSellExcessItems
            .ManufacturingFWUpgradeLevel = DefaultCalcManufacturingFWLevel
            .CopyingFWUpgradeLevel = DefaultCalcCopyingFWLevel
            .InventionFWUpgradeLevel = DefaultCalcInventionFWLevel
            .ColumnSort = DefaultCalcColumnSort
            .ColumnSortType = DefaultCalcColumnType
            .Score = DefaultCalcScore
            .RiskIPH = DefaultCalcRiskIPH
            .RiskProfit = DefaultCalcRiskProfit
            .RiskPrice = DefaultCalcRiskPrice
            .Volatility = DefaultCalcVolatility
            .PriceTrend = DefaultCalcPriceTrend
            .MinBuildTime = DefaultCalcMinBuildTime
            .MinBuildTimeCheck = DefaultCalcMinBuildTimeCheck
            .MaxBuildTime = DefaultCalcMaxBuildTime
            .MaxBuildTimeCheck = DefaultCalcMaxBuildTimeCheck
            .IPHThreshold = DefaultCalcIPHThreshold
            .IPHThresholdCheck = DefaultCalcIPHThresholdCheck
            .ProfitThreshold = DefaultCalcProfitThreshold
            .ProfitThresholdCheck = DefaultCalcProfitThresholdCheck
            .VolumeThreshold = DefaultCalcVolumeThreshold
            .VolumeThresholdCheck = DefaultCalcVolumeThresholdCheck
            .BuildT2T3Materials = CType(DefaultBuiltMatsType, BuildMatType)
        End With

        ' Save locally
        ManufacturingSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveManufacturingSettings(SentSettings As ManufacturingTabSettings)
        Dim ManufacturingSettingsList(91) As Setting

        Try
            ManufacturingSettingsList(0) = New Setting("BlueprintType", CStr(SentSettings.BlueprintType))
            ManufacturingSettingsList(1) = New Setting("CheckTech1", CStr(SentSettings.CheckTech1))
            ManufacturingSettingsList(2) = New Setting("CheckTech2", CStr(SentSettings.CheckTech2))
            ManufacturingSettingsList(3) = New Setting("CheckTech3", CStr(SentSettings.CheckTech3))
            ManufacturingSettingsList(4) = New Setting("CheckTechStoryline", CStr(SentSettings.CheckTechStoryline))
            ManufacturingSettingsList(5) = New Setting("CheckTechNavy", CStr(SentSettings.CheckTechNavy))
            ManufacturingSettingsList(6) = New Setting("CheckTechPirate", CStr(SentSettings.CheckTechPirate))
            ManufacturingSettingsList(7) = New Setting("ItemTypeFilter", CStr(SentSettings.ItemTypeFilter))
            ManufacturingSettingsList(8) = New Setting("TextItemFilter", CStr(SentSettings.TextItemFilter))
            ManufacturingSettingsList(9) = New Setting("CheckBPTypeShips", CStr(SentSettings.CheckBPTypeShips))
            ManufacturingSettingsList(10) = New Setting("CheckBPTypeDrones", CStr(SentSettings.CheckBPTypeDrones))
            ManufacturingSettingsList(11) = New Setting("CheckBPTypeComponents", CStr(SentSettings.CheckBPTypeComponents))
            ManufacturingSettingsList(12) = New Setting("CheckBPTypeStructures", CStr(SentSettings.CheckBPTypeStructures))
            ManufacturingSettingsList(13) = New Setting("CheckBPTypeMisc", CStr(SentSettings.CheckBPTypeMisc))
            ManufacturingSettingsList(14) = New Setting("CheckBPTypeModules", CStr(SentSettings.CheckBPTypeModules))
            ManufacturingSettingsList(15) = New Setting("CheckBPTypeAmmoCharges", CStr(SentSettings.CheckBPTypeAmmoCharges))
            ManufacturingSettingsList(16) = New Setting("CheckBPTypeRigs", CStr(SentSettings.CheckBPTypeRigs))
            ManufacturingSettingsList(17) = New Setting("CheckBPTypeSubsystems", CStr(SentSettings.CheckBPTypeSubsystems))
            ManufacturingSettingsList(18) = New Setting("CheckBPTypeBoosters", CStr(SentSettings.CheckBPTypeBoosters))
            ManufacturingSettingsList(19) = New Setting("CheckDecryptorNone", CStr(SentSettings.CheckDecryptorNone))
            ManufacturingSettingsList(20) = New Setting("CheckDecryptor06", CStr(SentSettings.CheckDecryptor06))
            ManufacturingSettingsList(21) = New Setting("CheckDecryptor10", CStr(SentSettings.CheckDecryptor10))
            ManufacturingSettingsList(22) = New Setting("CheckDecryptor11", CStr(SentSettings.CheckDecryptor11))
            ManufacturingSettingsList(23) = New Setting("CheckDecryptor12", CStr(SentSettings.CheckDecryptor12))
            ManufacturingSettingsList(24) = New Setting("CheckDecryptor18", CStr(SentSettings.CheckDecryptor18))
            ManufacturingSettingsList(25) = New Setting("CheckIgnoreInvention", CStr(SentSettings.CheckIgnoreInvention))
            ManufacturingSettingsList(26) = New Setting("CheckRelicWrecked", CStr(SentSettings.CheckRelicWrecked))
            ManufacturingSettingsList(27) = New Setting("CheckRelicIntact", CStr(SentSettings.CheckRelicIntact))
            ManufacturingSettingsList(28) = New Setting("CheckRelicMalfunction", CStr(SentSettings.CheckRelicMalfunction))
            ManufacturingSettingsList(29) = New Setting("CheckOnlyBuild", CStr(SentSettings.CheckOnlyBuild))
            ManufacturingSettingsList(30) = New Setting("CheckOnlyInvent", CStr(SentSettings.CheckOnlyInvent))
            ManufacturingSettingsList(31) = New Setting("CheckIncludeTaxes", CStr(SentSettings.CheckIncludeTaxes))
            ManufacturingSettingsList(32) = New Setting("CheckIncludeUsage", CStr(SentSettings.CheckIncludeUsage))
            ManufacturingSettingsList(33) = New Setting("CheckRaceAmarr", CStr(SentSettings.CheckRaceAmarr))
            ManufacturingSettingsList(34) = New Setting("CheckRaceCaldari", CStr(SentSettings.CheckRaceCaldari))
            ManufacturingSettingsList(35) = New Setting("CheckRaceGallente", CStr(SentSettings.CheckRaceGallente))
            ManufacturingSettingsList(36) = New Setting("CheckRaceMinmatar", CStr(SentSettings.CheckRaceMinmatar))
            ManufacturingSettingsList(37) = New Setting("CheckRacePirate", CStr(SentSettings.CheckRacePirate))
            ManufacturingSettingsList(38) = New Setting("CheckRaceOther", CStr(SentSettings.CheckRaceOther))
            ManufacturingSettingsList(39) = New Setting("PriceCompare", CStr(SentSettings.PriceCompare))
            ManufacturingSettingsList(40) = New Setting("CheckIncludeT2Owned", CStr(SentSettings.CheckIncludeT2Owned))
            ManufacturingSettingsList(41) = New Setting("CheckIncludeT3Owned", CStr(SentSettings.CheckIncludeT3Owned))
            ManufacturingSettingsList(42) = New Setting("CheckSVRIncludeNull", CStr(SentSettings.CheckSVRIncludeNull))
            ManufacturingSettingsList(43) = New Setting("ProductionLines", CStr(SentSettings.ProductionLines))
            ManufacturingSettingsList(44) = New Setting("LaboratoryLines", CStr(SentSettings.LaboratoryLines))
            ManufacturingSettingsList(45) = New Setting("CheckDecryptor09", CStr(SentSettings.CheckDecryptor09))
            ManufacturingSettingsList(46) = New Setting("CheckDecryptor15", CStr(SentSettings.CheckDecryptor15))
            ManufacturingSettingsList(47) = New Setting("CheckDecryptor19", CStr(SentSettings.CheckDecryptor19))
            ManufacturingSettingsList(48) = New Setting("Runs", CStr(SentSettings.Runs))
            ManufacturingSettingsList(49) = New Setting("CheckBPTypeCelestials", CStr(SentSettings.CheckBPTypeCelestials))
            ManufacturingSettingsList(50) = New Setting("CheckBPTypeDeployables", CStr(SentSettings.CheckBPTypeDeployables))
            ManufacturingSettingsList(51) = New Setting("CheckSmall", CStr(SentSettings.CheckSmall))
            ManufacturingSettingsList(52) = New Setting("CheckMedium", CStr(SentSettings.CheckMedium))
            ManufacturingSettingsList(53) = New Setting("CheckLarge", CStr(SentSettings.CheckLarge))
            ManufacturingSettingsList(54) = New Setting("CheckXL", CStr(SentSettings.CheckXL))
            ManufacturingSettingsList(55) = New Setting("CheckBPTypeStationParts", CStr(SentSettings.CheckBPTypeStationParts))
            ManufacturingSettingsList(56) = New Setting("CheckIncludeBrokersFees", CStr(SentSettings.CheckIncludeBrokersFees))
            ManufacturingSettingsList(57) = New Setting("CheckDecryptorUseforT2", CStr(SentSettings.CheckDecryptorUseforT2))
            ManufacturingSettingsList(58) = New Setting("CheckDecryptorUseforT3", CStr(SentSettings.CheckDecryptorUseforT3))
            ManufacturingSettingsList(59) = New Setting("CheckCapitalComponentsFacility", CStr(SentSettings.CheckCapitalComponentsFacility))
            ManufacturingSettingsList(60) = New Setting("CheckT3DestroyerFacility", CStr(SentSettings.CheckT3DestroyerFacility))
            ManufacturingSettingsList(61) = New Setting("BPRuns", CStr(SentSettings.BPRuns))
            ManufacturingSettingsList(62) = New Setting("CheckAutoCalcNumBPs", CStr(SentSettings.CheckAutoCalcNumBPs))
            ManufacturingSettingsList(63) = New Setting("IgnoreInvention", CStr(SentSettings.IgnoreInvention))
            ManufacturingSettingsList(64) = New Setting("IgnoreMinerals", CStr(SentSettings.IgnoreMinerals))
            ManufacturingSettingsList(65) = New Setting("IgnoreT1Item", CStr(SentSettings.IgnoreT1Item))
            ManufacturingSettingsList(66) = New Setting("CalcPPU", CStr(SentSettings.CalcPPU))
            ManufacturingSettingsList(67) = New Setting("ColumnSort", CStr(SentSettings.ColumnSort))
            ManufacturingSettingsList(68) = New Setting("ColumnSortType", CStr(SentSettings.ColumnSortType))
            ManufacturingSettingsList(69) = New Setting("ManufacturingFWUpgradeLevel", CStr(SentSettings.ManufacturingFWUpgradeLevel))
            ManufacturingSettingsList(70) = New Setting("CopyingFWUpgradeLevel", CStr(SentSettings.CopyingFWUpgradeLevel))
            ManufacturingSettingsList(71) = New Setting("PriceTrend", CStr(SentSettings.PriceTrend))
            ManufacturingSettingsList(72) = New Setting("MinBuildTime", CStr(SentSettings.MinBuildTime))
            ManufacturingSettingsList(73) = New Setting("MinBuildTimeCheck", CStr(SentSettings.MinBuildTimeCheck))
            ManufacturingSettingsList(74) = New Setting("MaxBuildTime", CStr(SentSettings.MaxBuildTime))
            ManufacturingSettingsList(75) = New Setting("MaxBuildTimeCheck", CStr(SentSettings.MaxBuildTimeCheck))
            ManufacturingSettingsList(76) = New Setting("IPHThreshold", CStr(SentSettings.IPHThreshold))
            ManufacturingSettingsList(77) = New Setting("IPHThresholdCheck", CStr(SentSettings.IPHThresholdCheck))
            ManufacturingSettingsList(78) = New Setting("ProfitThreshold", CStr(SentSettings.ProfitThreshold))
            ManufacturingSettingsList(79) = New Setting("ProfitThresholdCheck", CStr(SentSettings.ProfitThresholdCheck))
            ManufacturingSettingsList(80) = New Setting("VolumeThreshold", CStr(SentSettings.VolumeThreshold))
            ManufacturingSettingsList(81) = New Setting("VolumeThresholdCheck", CStr(SentSettings.VolumeThresholdCheck))
            ManufacturingSettingsList(82) = New Setting("CheckDecryptorOptimal", CStr(SentSettings.CheckDecryptorOptimal))
            ManufacturingSettingsList(83) = New Setting("CheckBPTypeStructureModules", CStr(SentSettings.CheckBPTypeStructureModules))
            ManufacturingSettingsList(84) = New Setting("CheckBPTypeReactions", CStr(SentSettings.CheckBPTypeReactions))
            ManufacturingSettingsList(85) = New Setting("CheckBPTypeNPCBPOs", CStr(SentSettings.CheckBPTypeNPCBPOs))
            ManufacturingSettingsList(86) = New Setting("CheckSellExcessItems", CStr(SentSettings.CheckSellExcessItems))
            ManufacturingSettingsList(87) = New Setting("CalcBrokerFeeRate", CStr(SentSettings.CalcBrokerFeeRate))
            ManufacturingSettingsList(88) = New Setting("BuildT2T3Materials", CStr(SentSettings.BuildT2T3Materials))
            ManufacturingSettingsList(89) = New Setting("Volatility", CStr(SentSettings.Volatility))
            ManufacturingSettingsList(90) = New Setting("Score", CStr(SentSettings.Score))
            ManufacturingSettingsList(90) = New Setting("RiskIPH", CStr(SentSettings.RiskIPH))
            ManufacturingSettingsList(90) = New Setting("RiskProfit", CStr(SentSettings.RiskProfit))
            ManufacturingSettingsList(91) = New Setting("RiskPrice", CStr(SentSettings.RiskPrice))

            Call WriteSettingsToFile(SettingsFolder, ManufacturingSettingsFileName, ManufacturingSettingsList, ManufacturingSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Manufacturing Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetManufacturingSettings() As ManufacturingTabSettings
        Return ManufacturingSettings
    End Function

#End Region

#Region "Datacore Tab Settings"

    ' Loads the tab settings
    Public Function LoadDatacoreSettings() As DataCoreTabSettings
        Dim TempSettings As DataCoreTabSettings = Nothing

        Try

            ' Dim the settings
            ReDim TempSettings.SkillsLevel(NumberofDCSettingsSkillRecords)
            ReDim TempSettings.SkillsChecked(NumberofDCSettingsSkillRecords)
            ReDim TempSettings.CorpsStanding(NumberofDCSettingsCorpRecords)
            ReDim TempSettings.CorpsChecked(NumberofDCSettingsCorpRecords)

            If FileExists(SettingsFolder, DatacoreSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .PricesFrom = CStr(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeString, DatacoreSettingsFileName, "PricesFrom", DefaultReactPOSFuelCost))
                    .CheckHighSecAgents = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckHighSecAgents", DefaultReactCheckTaxes))
                    .CheckLowNullSecAgents = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckLowNullSecAgents", DefaultReactCheckFees))
                    .CheckIncludeAgentsCannotAccess = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckIncludeAgentsCannotAccess", DefaultReactItemChecks))
                    .AgentsInRegion = CStr(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeString, DatacoreSettingsFileName, "AgentsInRegion", DefaultReactItemChecks))
                    .CheckSovAmarr = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovAmarr", DefaultReactItemChecks))
                    .CheckSovAmmatar = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovAmmatar", DefaultReactItemChecks))
                    .CheckSovGallente = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovGallente", DefaultReactItemChecks))
                    .CheckSovSyndicate = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovSyndicate", DefaultReactItemChecks))
                    .CheckSovKhanid = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovKhanid", DefaultReactItemChecks))
                    .CheckSovThukker = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovThukker", DefaultReactItemChecks))
                    .CheckSovCaldari = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovCaldari", DefaultReactItemChecks))
                    .CheckSovMinmatar = CBool(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovMinmatar", DefaultReactItemChecks))

                    For i = 1 To 17
                        .SkillsChecked(i - 1) = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Skill" & CStr(i) & "Checked", DefaultSkillLevelChecked))
                        .SkillsLevel(i - 1) = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Skill" & CStr(i) & "Level ", DefaultSkillLevel))
                    Next

                    For i = 1 To 13
                        .CorpsChecked(i - 1) = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Corp" & CStr(i) & "Checked", DefaultSkillLevelChecked))
                        .CorpsStanding(i - 1) = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Corp" & CStr(i) & "Standing ", DefaultSkillLevel))
                    Next

                    .Negotiation = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Negotiation", DefaultNegotiation))
                    .Connections = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Connections", DefaultConnections))
                    .ResearchProjectMgt = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "ResearchProjectMgt", DefaultResearchProjMgt))

                    .ColumnSort = CInt(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeInteger, DatacoreSettingsFileName, "ColumnSort", DefaultDCColumnSort))
                    .ColumnSortType = CStr(GetSettingValue(SettingsFolder, DatacoreSettingsFileName, SettingTypes.TypeString, DatacoreSettingsFileName, "ColumnSortType", DefaultDCColumnSortType))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultDatacoreSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Datacore Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultDatacoreSettings()
        End Try

        ' Save them locally and then export
        DatacoreSettings = TempSettings

        Return TempSettings

    End Function

    Public Function SetDefaultDatacoreSettings() As DataCoreTabSettings
        Dim LocalSettings As DataCoreTabSettings

        ReDim LocalSettings.SkillsChecked(NumberofDCSettingsSkillRecords)
        ReDim LocalSettings.SkillsLevel(NumberofDCSettingsSkillRecords)

        ReDim LocalSettings.CorpsChecked(NumberofDCSettingsCorpRecords)
        ReDim LocalSettings.CorpsStanding(NumberofDCSettingsCorpRecords)

        With LocalSettings
            .PricesFrom = DefaultDCPricesFrom
            .CheckHighSecAgents = DefaultDCCheckHighSec
            .CheckLowNullSecAgents = DefaultDCCheckLowNullSec
            .CheckIncludeAgentsCannotAccess = DefaultDCIncludeAgentsCantUse
            .AgentsInRegion = DefaultDCAgentsInRegion
            .CheckSovAmarr = DefaultDCSovCheck
            .CheckSovAmmatar = DefaultDCSovCheck
            .CheckSovGallente = DefaultDCSovCheck
            .CheckSovSyndicate = DefaultDCSovCheck
            .CheckSovKhanid = DefaultDCSovCheck
            .CheckSovThukker = DefaultDCSovCheck
            .CheckSovCaldari = DefaultDCSovCheck
            .CheckSovMinmatar = DefaultDCSovCheck

            For i = 0 To .SkillsChecked.Count - 1
                .SkillsChecked(i) = DefaultSkillLevelChecked
                .SkillsLevel(i) = DefaultSkillLevel
            Next

            For i = 0 To .CorpsChecked.Count - 1
                .CorpsChecked(i) = DefaultCorpStandingChecked
                .CorpsStanding(i) = DefaultCorpStanding
            Next

            .Negotiation = DefaultNegotiation
            .Connections = DefaultConnections
            .ResearchProjectMgt = DefaultResearchProjMgt

            .ColumnSort = DefaultDCColumnSort
            .ColumnSortType = DefaultDCColumnSortType

        End With
        ' Save locally
        DatacoreSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveDatacoreSettings(SentSettings As DataCoreTabSettings)
        Dim DatacoreSettingsList(77) As Setting
        Dim j As Integer

        Try
            DatacoreSettingsList(0) = New Setting("PricesFrom", CStr(SentSettings.PricesFrom))
            DatacoreSettingsList(1) = New Setting("CheckHighSecAgents", CStr(SentSettings.CheckHighSecAgents))
            DatacoreSettingsList(2) = New Setting("CheckLowNullSecAgents", CStr(SentSettings.CheckLowNullSecAgents))
            DatacoreSettingsList(3) = New Setting("CheckIncludeAgentsCannotAccess", CStr(SentSettings.CheckIncludeAgentsCannotAccess))
            DatacoreSettingsList(4) = New Setting("AgentsInRegion", CStr(SentSettings.AgentsInRegion))
            DatacoreSettingsList(5) = New Setting("CheckSovAmarr", CStr(SentSettings.CheckSovAmarr))
            DatacoreSettingsList(6) = New Setting("CheckSovAmmatar", CStr(SentSettings.CheckSovAmmatar))
            DatacoreSettingsList(7) = New Setting("CheckSovGallente", CStr(SentSettings.CheckSovGallente))
            DatacoreSettingsList(8) = New Setting("CheckSovSyndicate", CStr(SentSettings.CheckSovSyndicate))
            DatacoreSettingsList(9) = New Setting("CheckSovKhanid", CStr(SentSettings.CheckSovKhanid))
            DatacoreSettingsList(10) = New Setting("CheckSovThukker", CStr(SentSettings.CheckSovThukker))
            DatacoreSettingsList(11) = New Setting("CheckSovCaldari", CStr(SentSettings.CheckSovCaldari))
            DatacoreSettingsList(12) = New Setting("CheckSovMinmatar", CStr(SentSettings.CheckSovMinmatar))

            ' Skills
            j = 0
            For i = 13 To 29
                j += 1
                DatacoreSettingsList(i) = New Setting("Skill" & CStr(j) & "Level", CStr(SentSettings.SkillsLevel(j - 1)))
            Next

            j = 0
            For i = 30 To 46
                j += 1
                DatacoreSettingsList(i) = New Setting("Skill" & CStr(j) & "Checked", CStr(SentSettings.SkillsChecked(j - 1)))
            Next

            ' Corp Standings
            j = 0
            For i = 47 To 59
                j += 1
                DatacoreSettingsList(i) = New Setting("Corp" & CStr(j) & "Standing", CStr(SentSettings.CorpsStanding(j - 1)))
            Next

            j = 0
            For i = 60 To 72
                j += 1
                DatacoreSettingsList(i) = New Setting("Corp" & CStr(j) & "Checked", CStr(SentSettings.CorpsChecked(j - 1)))
            Next

            DatacoreSettingsList(73) = New Setting("Negotiation", CStr(SentSettings.Negotiation))
            DatacoreSettingsList(74) = New Setting("Connections", CStr(SentSettings.Connections))
            DatacoreSettingsList(75) = New Setting("ResearchProjectMgt", CStr(SentSettings.ResearchProjectMgt))

            DatacoreSettingsList(76) = New Setting("ColumnSort", CStr(SentSettings.ColumnSort))
            DatacoreSettingsList(77) = New Setting("ColumnSortType", CStr(SentSettings.ColumnSortType))

            Call WriteSettingsToFile(SettingsFolder, DatacoreSettingsFileName, DatacoreSettingsList, DatacoreSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Datacore Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetDatacoreSettings() As DataCoreTabSettings
        Return DatacoreSettings
    End Function

#End Region

#Region "Reactions Tab Settings"

    ' Loads the tab settings
    Public Function LoadReactionSettings() As ReactionsTabSettings
        Dim TempSettings As ReactionsTabSettings = Nothing

        Try
            If FileExists(SettingsFolder, ReactionSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .POSFuelCost = CDbl(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeDouble, ReactionSettingsFileName, "POSFuelCost", DefaultReactPOSFuelCost))
                    .CheckTaxes = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckTaxes", DefaultReactCheckTaxes))
                    .CheckFees = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckFees", DefaultReactCheckFees))
                    .CheckAdvMoonMats = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckAdvMoonMats", DefaultReactItemChecks))
                    .CheckProcessedMoonMats = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckProcessedMoonMats", DefaultReactItemChecks))
                    .CheckHybrid = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckHybrid", DefaultReactItemChecks))
                    .CheckComplexBio = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckComplexBio", DefaultReactItemChecks))
                    .CheckSimpleBio = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckSimpleBio", DefaultReactItemChecks))
                    .CheckBuildBasic = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckBuildBasic", DefaultReactItemChecks))
                    .CheckIgnoreMarket = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckIgnoreMarket", DefaultReactItemChecks))
                    .CheckRefine = CBool(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeBoolean, ReactionSettingsFileName, "CheckRefine", DefaultReactItemChecks))
                    .NumberofPOS = CInt(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeInteger, ReactionSettingsFileName, "NumberofPOS", DefaultReactNumPOS))
                    .RefineryEfficiency = CDbl(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeDouble, ReactionSettingsFileName, "RefineryEfficiency", DefaultRefiningEfficency))
                    .RefineryTax = CDbl(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeDouble, ReactionSettingsFileName, "RefineryTax", DefaultRefineTax))
                    .RefineryStanding = CDbl(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeDouble, ReactionSettingsFileName, "RefineryStanding", DefaultRefineCorpStanding))
                    .ColumnSort = CInt(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeInteger, ReactionSettingsFileName, "ColumnSort", DefaultReactColumnSort))
                    .ColumnSortType = CStr(GetSettingValue(SettingsFolder, ReactionSettingsFileName, SettingTypes.TypeString, ReactionSettingsFileName, "ColumnSortType", DefaultReactColumnSortType))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultReactionSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Reaction Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultReactionSettings()
        End Try

        ' Save them locally and then export
        ReactionSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultReactionSettings() As ReactionsTabSettings
        Dim LocalSettings As ReactionsTabSettings

        LocalSettings.POSFuelCost = DefaultReactPOSFuelCost
        LocalSettings.CheckTaxes = DefaultReactCheckTaxes
        LocalSettings.CheckFees = DefaultReactCheckFees
        LocalSettings.CheckAdvMoonMats = DefaultReactItemChecks
        LocalSettings.CheckProcessedMoonMats = DefaultReactItemChecks
        LocalSettings.CheckHybrid = DefaultReactItemChecks
        LocalSettings.CheckComplexBio = DefaultReactItemChecks
        LocalSettings.CheckSimpleBio = DefaultReactItemChecks
        LocalSettings.CheckBuildBasic = DefaultReactItemChecks
        LocalSettings.CheckIgnoreMarket = DefaultReactItemChecks
        LocalSettings.CheckRefine = DefaultReactItemChecks
        LocalSettings.NumberofPOS = DefaultReactNumPOS
        LocalSettings.RefineryEfficiency = DefaultRefiningEfficency
        LocalSettings.RefineryTax = DefaultRefineTax
        LocalSettings.RefineryStanding = DefaultRefineCorpStanding
        LocalSettings.ColumnSort = DefaultReactColumnSort
        LocalSettings.ColumnSortType = DefaultReactColumnSortType

        ' Save locally
        ReactionSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveReactionSettings(SentSettings As ReactionsTabSettings)
        Dim ReactionSettingsList(16) As Setting

        Try
            ReactionSettingsList(0) = New Setting("POSFuelCost", CStr(SentSettings.POSFuelCost))
            ReactionSettingsList(1) = New Setting("CheckTaxes", CStr(SentSettings.CheckTaxes))
            ReactionSettingsList(2) = New Setting("CheckFees", CStr(SentSettings.CheckFees))
            ReactionSettingsList(3) = New Setting("CheckAdvMoonMats", CStr(SentSettings.CheckAdvMoonMats))
            ReactionSettingsList(4) = New Setting("CheckProcessedMoonMats", CStr(SentSettings.CheckProcessedMoonMats))
            ReactionSettingsList(5) = New Setting("CheckHybrid", CStr(SentSettings.CheckHybrid))
            ReactionSettingsList(6) = New Setting("CheckComplexBio", CStr(SentSettings.CheckComplexBio))
            ReactionSettingsList(7) = New Setting("CheckSimpleBio", CStr(SentSettings.CheckSimpleBio))
            ReactionSettingsList(8) = New Setting("CheckBuildBasic", CStr(SentSettings.CheckBuildBasic))
            ReactionSettingsList(9) = New Setting("CheckIgnoreMarket", CStr(SentSettings.CheckIgnoreMarket))
            ReactionSettingsList(10) = New Setting("CheckRefine", CStr(SentSettings.CheckRefine))
            ReactionSettingsList(11) = New Setting("NumberofPOS", CStr(SentSettings.NumberofPOS))
            ReactionSettingsList(12) = New Setting("RefineryEfficiency", CStr(SentSettings.RefineryEfficiency))
            ReactionSettingsList(13) = New Setting("RefineryTax", CStr(SentSettings.RefineryTax))
            ReactionSettingsList(14) = New Setting("RefineryStanding", CStr(SentSettings.RefineryStanding))
            ReactionSettingsList(15) = New Setting("ColumnSort", CStr(SentSettings.ColumnSort))
            ReactionSettingsList(16) = New Setting("ColumnSortType", CStr(SentSettings.ColumnSortType))

            Call WriteSettingsToFile(SettingsFolder, ReactionSettingsFileName, ReactionSettingsList, ReactionSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Reaction Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetReactionSettings() As ReactionsTabSettings
        Return ReactionSettings
    End Function

#End Region

#Region "Mining Tab Settings"

    ' Loads the tab settings
    Public Function LoadMiningSettings() As MiningTabSettings
        Dim TempSettings As MiningTabSettings = Nothing

        Try
            If FileExists(SettingsFolder, MiningSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .OreType = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "OreType", DefaultMiningOreType))
                    .CheckHighYieldOres = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckHighYieldOres", DefaultMiningCheckHighYieldOres))
                    .CheckHighSecOres = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckHighSecOres", DefaultMiningCheckHighSecOres))
                    .CheckLowSecOres = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckLowSecOres", DefaultMiningCheckLowSecOres))
                    .CheckNullSecOres = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckNullSecOres", DefaultMiningCheckNullSecOres))
                    .CheckSovAmarr = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovAmarr", DefaultMiningCheckSovAmarr))
                    .CheckSovCaldari = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovCaldari", DefaultMiningCheckSovCaldari))
                    .CheckSovGallente = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovGallente", DefaultMiningCheckSovGallente))
                    .CheckSovMinmatar = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovMinmatar", DefaultMiningCheckSovMinmatar))
                    .CheckSovTriglavian = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovTriglavian", DefaultMiningCheckSovTriglavian))
                    .CheckIncludeFees = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckIncludeFees", DefaultMiningCheckIncludeFees))
                    .BrokerFeeRate = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "BrokerFeeRate", DefaultMiningBrokerFeeRate))
                    .CheckIncludeTaxes = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckIncludeTaxes", DefaultMiningCheckIncludeTaxes))
                    .CheckIncludeJumpFuelCosts = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckIncludeJumpFuelCosts", DefaultMiningCheckIncludeJumpFuelCosts))
                    .TotalJumpFuelCost = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "TotalJumpFuelCost", DefaultMiningTotalJumpFuelCost))
                    .TotalJumpFuelM3 = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "TotalJumpFuelM3", DefaultMiningTotalJumpFuelM3))
                    .JumpCompressedOre = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "JumpCompressedOre", DefaultMiningJumpCompressedOre))
                    .JumpMinerals = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "JumpMinerals", DefaultMiningJumpMinerals))
                    .OreMiningShip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "OreMiningShip", DefaultMiningMiningShip))
                    .IceMiningShip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "IceMiningShip", DefaultMiningIceMiningShip))
                    .GasMiningShip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "GasMiningShip", DefaultMiningGasMiningShip))
                    .OreStrip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "OreStrip", DefaultMiningOreStrip))
                    .IceStrip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "IceStrip", DefaultMiningIceStrip))
                    .GasHarvester = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "GasHarvester", DefaultMiningGasHarvester))
                    .NumOreMiners = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumOreMiners", DefaultMiningNumOreMiners))
                    .NumIceMiners = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumIceMiners", DefaultMiningNumIceMiners))
                    .NumGasHarvesters = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumGasHarvesters", DefaultMiningNumGasHarvesters))
                    .OreUpgrade = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "OreUpgrade", DefaultMiningOreUpgrade))
                    .IceUpgrade = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "IceUpgrade", DefaultMiningIceUpgrade))
                    .GasUpgrade = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "GasUpgrade", DefaultMiningGasUpgrade))
                    .NumOreUpgrades = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumOreUpgrades", DefaultMiningNumOreUpgrades))
                    .NumIceUpgrades = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumIceUpgrades", DefaultMiningNumIceUpgrades))
                    .NumGasUpgrades = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumGasUpgrades", DefaultMiningNumGasUpgrades))
                    .MichiiImplant = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "MichiiImplant", DefaultMiningMichiiImplant))
                    .T2Crystals = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "T2Crystals", DefaultMiningT2Crystals))
                    .OreImplant = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "OreImplant", DefaultMiningOreImplant))
                    .IceImplant = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "IceImplant", DefaultMiningIceImplant))
                    .GasImplant = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "GasImplant", DefaultMiningGasImplant))
                    .CheckUseHauler = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckUseHauler", DefaultMiningCheckUseHauler))
                    .RoundTripMin = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "RoundTripMin", DefaultMiningRoundTripMin))
                    .RoundTripSec = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "RoundTripSec", DefaultMiningRoundTripSec))
                    .Haulerm3 = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "Haulerm3", DefaultMiningHaulerm3))
                    .CheckUseFleetBooster = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckUseFleetBooster", DefaultMiningCheckUseFleetBooster))
                    .BoosterShip = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "BoosterShip", DefaultMiningBoosterShip))
                    .BoosterShipSkill = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterShipSkill", DefaultMiningBoosterShipSkill))
                    .MiningFormanSkill = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "MiningFormanSkill", DefaultMiningMiningFormanSkill))
                    .MiningDirectorSkill = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "MiningDirectorSkill", DefaultMiningMiningDirectorSkill))
                    .CheckMineForemanLaserOpBoost = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckMineForemanLaserOpBoost", DefaultMiningCheckMineForemanLaserOpBoost))
                    .CheckMineForemanLaserRangeBoost = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckMineForemanLaserRangeBoost", DefaultMiningCheckMineForemanLaserOpBoost))
                    .CheckMiningForemanMindLink = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckMiningForemanMindLink", DefaultMiningCheckMiningForemanMindLink))
                    .CheckRorqDeployed = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckRorqDeployed", DefaultMiningRorqDeployed))
                    .MiningDroneM3perHour = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "MiningDroneM3perHour", DefaultMiningDroneM3perHour))
                    .RefinedOre = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "RefinedOre", DefaultMiningRefinedOre))
                    .UnrefinedOre = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "UnrefinedOre", DefaultMiningUnrefinedOre))
                    .CompressedOre = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CompressedOre", DefaultMiningCompressedOre))
                    .IndustrialReconfig = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "IndustrialReconfig", DefaultMiningIndustrialReconfig))
                    .MercoxitMiningRig = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "MercoxitMiningRig", DefaultMiningRig))
                    .IceMiningRig = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "IceMiningRig", DefaultMiningRig))
                    .CheckSovWormhole = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovWormhole", DefaultMiningCheckSovWormhole))
                    .CheckSovMoon = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovMoon", DefaultMiningCheckSovMoon))
                    .CheckSovC1 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC1", DefaultMiningCheckSovC1))
                    .CheckSovC2 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC2", DefaultMiningCheckSovC2))
                    .CheckSovC3 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC3", DefaultMiningCheckSovC3))
                    .CheckSovC4 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC4", DefaultMiningCheckSovC4))
                    .CheckSovC5 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC5", DefaultMiningCheckSovC5))
                    .CheckSovC6 = CBool(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC6", DefaultMiningCheckSovC6))
                    .NumberofMiners = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "NumberofMiners", DefaultMiningNumberofMiners))
                    .RefiningEfficiency = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "RefiningEfficiency", DefaultRefiningEfficency))
                    .RefineCorpStanding = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "RefineCorpStanding", DefaultRefineCorpStanding))
                    .RefiningTax = CDbl(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeDouble, MiningSettingsFileName, "RefiningTax", DefaultRefineTax))
                    .ColumnSort = CInt(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeInteger, MiningSettingsFileName, "ColumnSort", DefaultMiningColumnSort))
                    .ColumnSortType = CStr(GetSettingValue(SettingsFolder, MiningSettingsFileName, SettingTypes.TypeString, MiningSettingsFileName, "ColumnSortType", DefaultMiningColumnSortType))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultMiningSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Mining Tab Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultMiningSettings()
        End Try

        ' Save them locally and then export
        MiningSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultMiningSettings() As MiningTabSettings
        Dim LocalSettings As MiningTabSettings

        With LocalSettings
            .OreType = DefaultMiningOreType
            .CheckHighYieldOres = DefaultMiningCheckHighYieldOres
            .CheckHighSecOres = DefaultMiningCheckHighSecOres
            .CheckLowSecOres = DefaultMiningCheckLowSecOres
            .CheckNullSecOres = DefaultMiningCheckNullSecOres
            .CheckSovAmarr = DefaultMiningCheckSovAmarr
            .CheckSovCaldari = DefaultMiningCheckSovCaldari
            .CheckSovGallente = DefaultMiningCheckSovGallente
            .CheckSovMinmatar = DefaultMiningCheckSovMinmatar
            .CheckSovTriglavian = DefaultMiningCheckSovTriglavian
            .CheckSovWormhole = DefaultMiningCheckSovWormhole
            .CheckSovMoon = DefaultMiningCheckSovMoon
            .CheckSovC1 = DefaultMiningCheckSovC1
            .CheckSovC2 = DefaultMiningCheckSovC2
            .CheckSovC3 = DefaultMiningCheckSovC3
            .CheckSovC4 = DefaultMiningCheckSovC4
            .CheckSovC5 = DefaultMiningCheckSovC5
            .CheckSovC6 = DefaultMiningCheckSovC6
            .CheckIncludeFees = DefaultMiningCheckIncludeFees
            .BrokerFeeRate = DefaultMiningBrokerFeeRate
            .CheckIncludeTaxes = DefaultMiningCheckIncludeTaxes
            .CheckIncludeJumpFuelCosts = DefaultMiningCheckIncludeJumpFuelCosts
            .TotalJumpFuelCost = DefaultMiningTotalJumpFuelCost
            .TotalJumpFuelM3 = DefaultMiningTotalJumpFuelM3
            .JumpCompressedOre = DefaultMiningJumpCompressedOre
            .JumpMinerals = DefaultMiningJumpMinerals
            .OreMiningShip = DefaultMiningMiningShip
            .IceMiningShip = DefaultMiningIceMiningShip
            .GasMiningShip = DefaultMiningGasMiningShip
            .OreStrip = DefaultMiningOreStrip
            .IceStrip = DefaultMiningIceStrip
            .GasHarvester = DefaultMiningGasHarvester
            .NumOreMiners = DefaultMiningNumOreMiners
            .NumIceMiners = DefaultMiningNumIceMiners
            .NumGasHarvesters = DefaultMiningNumGasHarvesters
            .OreUpgrade = DefaultMiningOreUpgrade
            .IceUpgrade = DefaultMiningIceUpgrade
            .GasUpgrade = DefaultMiningGasUpgrade
            .NumOreUpgrades = DefaultMiningNumOreUpgrades
            .NumIceUpgrades = DefaultMiningNumIceUpgrades
            .NumGasUpgrades = DefaultMiningNumGasUpgrades
            .MichiiImplant = DefaultMiningMichiiImplant
            .T2Crystals = DefaultMiningT2Crystals
            .OreImplant = DefaultMiningOreImplant
            .IceImplant = DefaultMiningIceImplant
            .GasImplant = DefaultMiningGasImplant
            .CheckUseHauler = DefaultMiningCheckUseHauler
            .RoundTripMin = DefaultMiningRoundTripMin
            .RoundTripSec = DefaultMiningRoundTripSec
            .Haulerm3 = DefaultMiningHaulerm3
            .CheckUseFleetBooster = DefaultMiningCheckUseFleetBooster
            .BoosterShip = DefaultMiningBoosterShip
            .BoosterShipSkill = DefaultMiningBoosterShipSkill
            .MiningFormanSkill = DefaultMiningMiningFormanSkill
            .MiningDirectorSkill = DefaultMiningMiningDirectorSkill
            .CheckMineForemanLaserOpBoost = DefaultMiningCheckMineForemanLaserOpBoost
            .CheckMineForemanLaserRangeBoost = DefaultMiningCheckMineForemanLaserOpBoost
            .CheckMiningForemanMindLink = DefaultMiningCheckMiningForemanMindLink
            .CheckRorqDeployed = DefaultMiningRorqDeployed
            .MiningDroneM3perHour = DefaultMiningDroneM3perHour
            .RefinedOre = DefaultMiningRefinedOre
            .UnrefinedOre = DefaultMiningUnrefinedOre
            .CompressedOre = DefaultMiningCompressedOre
            .IndustrialReconfig = DefaultMiningIndustrialReconfig
            .MercoxitMiningRig = DefaultMiningRig
            .IceMiningRig = DefaultMiningRig
            .NumberofMiners = DefaultNumMiners
            .RefineCorpStanding = DefaultRefineCorpStanding
            .RefiningEfficiency = DefaultRefiningEfficency
            .RefiningTax = DefaultRefineTax
            .ColumnSort = DefaultMiningColumnSort
            .ColumnSortType = DefaultMiningColumnSortType
        End With

        ' Save locally
        MiningSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveMiningSettings(SentSettings As MiningTabSettings)
        Dim MiningSettingsList(71) As Setting

        Try
            MiningSettingsList(0) = New Setting("OreType", CStr(SentSettings.OreType))
            MiningSettingsList(1) = New Setting("CheckHighYieldOres", CStr(SentSettings.CheckHighYieldOres))
            MiningSettingsList(2) = New Setting("CheckHighSecOres", CStr(SentSettings.CheckHighSecOres))
            MiningSettingsList(3) = New Setting("CheckLowSecOres", CStr(SentSettings.CheckLowSecOres))
            MiningSettingsList(4) = New Setting("CheckNullSecOres", CStr(SentSettings.CheckNullSecOres))
            MiningSettingsList(5) = New Setting("CheckSovAmarr", CStr(SentSettings.CheckSovAmarr))
            MiningSettingsList(6) = New Setting("CheckSovCaldari", CStr(SentSettings.CheckSovCaldari))
            MiningSettingsList(7) = New Setting("CheckSovGallente", CStr(SentSettings.CheckSovGallente))
            MiningSettingsList(8) = New Setting("CheckSovMinmatar", CStr(SentSettings.CheckSovMinmatar))
            MiningSettingsList(9) = New Setting("CheckIncludeFees", CStr(SentSettings.CheckIncludeFees))
            MiningSettingsList(10) = New Setting("CheckIncludeTaxes", CStr(SentSettings.CheckIncludeTaxes))
            MiningSettingsList(11) = New Setting("CheckIncludeJumpFuelCosts", CStr(SentSettings.CheckIncludeJumpFuelCosts))
            MiningSettingsList(12) = New Setting("TotalJumpFuelCost", CStr(SentSettings.TotalJumpFuelCost))
            MiningSettingsList(13) = New Setting("TotalJumpFuelM3", CStr(SentSettings.TotalJumpFuelM3))
            MiningSettingsList(14) = New Setting("JumpCompressedOre", CStr(SentSettings.JumpCompressedOre))
            MiningSettingsList(15) = New Setting("JumpMinerals", CStr(SentSettings.JumpMinerals))
            MiningSettingsList(16) = New Setting("OreMiningShip", CStr(SentSettings.OreMiningShip))
            MiningSettingsList(17) = New Setting("IceMiningShip", CStr(SentSettings.IceMiningShip))
            MiningSettingsList(18) = New Setting("OreStrip", CStr(SentSettings.OreStrip))
            MiningSettingsList(19) = New Setting("IceStrip", CStr(SentSettings.IceStrip))
            MiningSettingsList(20) = New Setting("NumOreMiners", CStr(SentSettings.NumOreMiners))
            MiningSettingsList(21) = New Setting("NumIceMiners", CStr(SentSettings.NumIceMiners))
            MiningSettingsList(22) = New Setting("OreUpgrade", CStr(SentSettings.OreUpgrade))
            MiningSettingsList(23) = New Setting("IceUpgrade", CStr(SentSettings.IceUpgrade))
            MiningSettingsList(24) = New Setting("NumOreUpgrades", CStr(SentSettings.NumOreUpgrades))
            MiningSettingsList(25) = New Setting("NumIceUpgrades", CStr(SentSettings.NumIceUpgrades))
            MiningSettingsList(26) = New Setting("MichiiImplant", CStr(SentSettings.MichiiImplant))
            MiningSettingsList(27) = New Setting("T2Crystals", CStr(SentSettings.T2Crystals))
            MiningSettingsList(28) = New Setting("OreImplant", CStr(SentSettings.OreImplant))
            MiningSettingsList(29) = New Setting("IceImplant", CStr(SentSettings.IceImplant))
            MiningSettingsList(30) = New Setting("CheckUseHauler", CStr(SentSettings.CheckUseHauler))
            MiningSettingsList(31) = New Setting("RoundTripMin", CStr(SentSettings.RoundTripMin))
            MiningSettingsList(32) = New Setting("RoundTripSec", CStr(SentSettings.RoundTripSec))
            MiningSettingsList(33) = New Setting("Haulerm3", CStr(SentSettings.Haulerm3))
            MiningSettingsList(34) = New Setting("CheckUseFleetBooster", CStr(SentSettings.CheckUseFleetBooster))
            MiningSettingsList(35) = New Setting("BoosterShip", CStr(SentSettings.BoosterShip))
            MiningSettingsList(36) = New Setting("BoosterShipSkill", CStr(SentSettings.BoosterShipSkill))
            MiningSettingsList(37) = New Setting("MiningFormanSkill", CStr(SentSettings.MiningFormanSkill))
            MiningSettingsList(38) = New Setting("MiningDirectorSkill", CStr(SentSettings.MiningDirectorSkill))
            MiningSettingsList(39) = New Setting("CheckMineForemanLaserOpBoost", CStr(SentSettings.CheckMineForemanLaserOpBoost))
            MiningSettingsList(40) = New Setting("CheckMiningForemanMindLink", CStr(SentSettings.CheckMiningForemanMindLink))
            MiningSettingsList(41) = New Setting("CheckRorqDeployed", CStr(SentSettings.CheckRorqDeployed))
            MiningSettingsList(42) = New Setting("MiningDroneM3perHour", CStr(SentSettings.MiningDroneM3perHour))
            MiningSettingsList(43) = New Setting("RefinedOre", CStr(SentSettings.RefinedOre))
            MiningSettingsList(44) = New Setting("IndustrialReconfig", CStr(SentSettings.IndustrialReconfig))
            MiningSettingsList(45) = New Setting("MercoxitMiningRig", CStr(SentSettings.MercoxitMiningRig))
            MiningSettingsList(46) = New Setting("IceMiningRig", CStr(SentSettings.IceMiningRig))
            MiningSettingsList(47) = New Setting("CheckMineForemanLaserRangeBoost", CStr(SentSettings.CheckMineForemanLaserRangeBoost))
            MiningSettingsList(48) = New Setting("GasMiningShip", CStr(SentSettings.GasMiningShip))
            MiningSettingsList(49) = New Setting("GasHarvester", CStr(SentSettings.GasHarvester))
            MiningSettingsList(50) = New Setting("NumGasHarvesters", CStr(SentSettings.NumGasHarvesters))
            MiningSettingsList(51) = New Setting("GasUpgrade", CStr(SentSettings.GasUpgrade))
            MiningSettingsList(52) = New Setting("NumGasUpgrades", CStr(SentSettings.NumGasUpgrades))
            MiningSettingsList(53) = New Setting("GasImplant", CStr(SentSettings.GasImplant))
            MiningSettingsList(54) = New Setting("CheckSovWormhole", CStr(SentSettings.CheckSovWormhole))
            MiningSettingsList(55) = New Setting("CheckSovC1", CStr(SentSettings.CheckSovC1))
            MiningSettingsList(56) = New Setting("CheckSovC2", CStr(SentSettings.CheckSovC2))
            MiningSettingsList(57) = New Setting("CheckSovC3", CStr(SentSettings.CheckSovC3))
            MiningSettingsList(58) = New Setting("CheckSovC4", CStr(SentSettings.CheckSovC4))
            MiningSettingsList(59) = New Setting("CheckSovC5", CStr(SentSettings.CheckSovC5))
            MiningSettingsList(60) = New Setting("CheckSovC6", CStr(SentSettings.CheckSovC6))
            MiningSettingsList(61) = New Setting("CompressedOre", CStr(SentSettings.CompressedOre))
            MiningSettingsList(62) = New Setting("UnrefinedOre", CStr(SentSettings.UnrefinedOre))
            MiningSettingsList(63) = New Setting("NumberofMiners", CStr(SentSettings.NumberofMiners))

            MiningSettingsList(64) = New Setting("RefiningEfficiency", CStr(SentSettings.RefiningEfficiency))
            MiningSettingsList(65) = New Setting("RefineCorpStanding", CStr(SentSettings.RefineCorpStanding))
            MiningSettingsList(66) = New Setting("RefiningTax", CStr(SentSettings.RefiningTax))

            MiningSettingsList(67) = New Setting("ColumnSort", CStr(SentSettings.ColumnSort))
            MiningSettingsList(68) = New Setting("ColumnSortType", CStr(SentSettings.ColumnSortType))

            MiningSettingsList(69) = New Setting("CheckSovMoon", CStr(SentSettings.CheckSovMoon))
            MiningSettingsList(70) = New Setting("BrokerFeeRate", CStr(SentSettings.BrokerFeeRate))
            MiningSettingsList(71) = New Setting("CheckSovTriglavian", CStr(SentSettings.CheckSovTriglavian))

            Call WriteSettingsToFile(SettingsFolder, MiningSettingsFileName, MiningSettingsList, MiningSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Mining Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetMiningSettings() As MiningTabSettings
        Return MiningSettings
    End Function

#End Region

#Region "Industry Jobs Column Settings"

    ' Loads the tab settings
    Public Function LoadIndustryJobsColumnSettings() As IndustryJobsColumnSettings
        Dim TempSettings As IndustryJobsColumnSettings = Nothing

        Try
            If FileExists(SettingsFolder, IndustryJobsColumnSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .JobState = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobState", DefaultJobState))
                    .InstallerName = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallerName", DefaultInstallerName))
                    .TimeToComplete = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "TimeToComplete", DefaultTimeToComplete))
                    .Activity = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Activity", DefaultActivity))
                    .Status = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Status", DefaultStatus))
                    .StartTime = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StartTime", DefaultStartTime))
                    .EndTime = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "EndTime", DefaultEndTime))
                    .CompletionTime = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "CompletionTime", DefaultCompletionTime))
                    .Blueprint = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Blueprint", DefaultBlueprint))
                    .OutputItem = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItem", DefaultOutputItem))
                    .OutputItemType = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemType", DefaultOutputItemType))
                    .InstallSystem = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallSystem", DefaultInstallSolarSystem))
                    .InstallRegion = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallRegion", DefaultInstallRegion))
                    .LicensedRuns = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LicensedRuns", DefaultLicensedRuns))
                    .Runs = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Runs", DefaultRuns))
                    .SuccessfulRuns = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "SuccessfulRuns", DefaultSuccessfulRuns))
                    .BlueprintLocation = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintLocation", DefaultBlueprintLocation))
                    .OutputLocation = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputLocation", DefaultOutputLocation))
                    .JobType = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobType", DefaultJobType))

                    .JobStateWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobStateWidth", DefaultIndustryColumnWidth))
                    .InstallerNameWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallerNameWidth", DefaultIndustryColumnWidth))
                    .TimeToCompleteWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "TimeToCompleteWidth", DefaultIndustryColumnWidth))
                    .ActivityWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "ActivityWidth", DefaultIndustryColumnWidth))
                    .StatusWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StatusWidth", DefaultIndustryColumnWidth))
                    .StartTimeWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StartTimewidth", DefaultIndustryColumnWidth))
                    .EndTimeWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "EndTimeWidth", DefaultIndustryColumnWidth))
                    .CompletionTimeWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "CompletionTimeWidth", DefaultIndustryColumnWidth))
                    .BlueprintWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintWidth", DefaultIndustryColumnWidth))
                    .OutputItemWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemWidth", DefaultIndustryColumnWidth))
                    .OutputItemTypeWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemTypeWidth", DefaultIndustryColumnWidth))
                    .InstallSystemWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallSystemWidth", DefaultIndustryColumnWidth))
                    .InstallRegionWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallRegionWidth", DefaultIndustryColumnWidth))
                    .LicensedRunsWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LiscencedRunsWidth", DefaultIndustryColumnWidth))
                    .RunsWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "RunsWidth", DefaultIndustryColumnWidth))
                    .SuccessfulRunsWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "SuccessfulRunsWidth", DefaultIndustryColumnWidth))
                    .BlueprintLocationWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintLocationWidth", DefaultIndustryColumnWidth))
                    .OutputLocationWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputLocationWidth", DefaultIndustryColumnWidth))
                    .JobTypeWidth = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobTypeWidth", DefaultIndustryColumnWidth))

                    .OrderByColumn = CInt(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OrderByColumn", DefaultOrderByColumn))
                    .ViewJobType = CStr(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "ViewJobType", DefaultViewJobType))
                    .OrderType = CStr(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "OrderType", DefaultOrderType))
                    .JobTimes = CStr(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "JobTimes", DefaultJobTimes))
                    .SelectedCharacterIDs = CStr(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "SelectedCharacterIDs", DefaultSelectedCharacterIDs))
                    .AutoUpdateJobs = CBool(GetSettingValue(SettingsFolder, IndustryJobsColumnSettingsFileName, SettingTypes.TypeBoolean, IndustryJobsColumnSettingsFileName, "AutoUpdateJobs", DefaultAutoUpdateJobs))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultIndustryJobsColumnSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Industry Jobs Column Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultIndustryJobsColumnSettings()
        End Try

        ' Save them locally and then export
        IndustryJobsColumnSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultIndustryJobsColumnSettings() As IndustryJobsColumnSettings
        Dim LocalSettings As IndustryJobsColumnSettings

        With LocalSettings
            .JobState = DefaultJobState
            .InstallerName = DefaultInstallerName
            .TimeToComplete = DefaultTimeToComplete
            .Activity = DefaultActivity
            .Status = DefaultStatus
            .StartTime = DefaultStartTime
            .EndTime = DefaultEndTime
            .CompletionTime = DefaultCompletionTime
            .Blueprint = DefaultBlueprint
            .OutputItem = DefaultOutputItem
            .OutputItemType = DefaultOutputItemType
            .InstallSystem = DefaultInstallSolarSystem
            .InstallRegion = DefaultInstallRegion
            .LicensedRuns = DefaultLicensedRuns
            .Runs = DefaultRuns
            .BlueprintLocation = DefaultBlueprintLocation
            .SuccessfulRuns = DefaultSuccessfulRuns
            .OutputLocation = DefaultOutputLocation
            .JobType = DefaultJobType

            .JobStateWidth = DefaultIndustryColumnWidth
            .InstallerNameWidth = DefaultIndustryColumnWidth
            .TimeToCompleteWidth = DefaultIndustryColumnWidth
            .ActivityWidth = DefaultIndustryColumnWidth
            .StatusWidth = DefaultIndustryColumnWidth
            .StartTimeWidth = DefaultIndustryColumnWidth
            .EndTimeWidth = DefaultIndustryColumnWidth
            .CompletionTimeWidth = DefaultIndustryColumnWidth
            .BlueprintWidth = DefaultIndustryColumnWidth
            .OutputItemWidth = DefaultIndustryColumnWidth
            .OutputItemTypeWidth = DefaultIndustryColumnWidth
            .InstallSystemWidth = DefaultIndustryColumnWidth
            .InstallRegionWidth = DefaultIndustryColumnWidth
            .LicensedRunsWidth = DefaultIndustryColumnWidth
            .RunsWidth = DefaultIndustryColumnWidth
            .SuccessfulRunsWidth = DefaultIndustryColumnWidth
            .BlueprintLocationWidth = DefaultIndustryColumnWidth
            .OutputLocationWidth = DefaultIndustryColumnWidth
            .JobTypeWidth = DefaultIndustryColumnWidth

            .OrderByColumn = DefaultOrderByColumn
            .OrderType = DefaultOrderType
            .ViewJobType = DefaultViewJobType
            .JobTimes = DefaultJobTimes

            .SelectedCharacterIDs = DefaultSelectedCharacterIDs

            .AutoUpdateJobs = DefaultAutoUpdateJobs

        End With

        ' Save locally
        IndustryJobsColumnSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveIndustryJobsColumnSettings(SentSettings As IndustryJobsColumnSettings)
        Dim IndustryJobsColumnSettingsList(43) As Setting

        Try
            IndustryJobsColumnSettingsList(0) = New Setting("JobState", CStr(SentSettings.JobState))
            IndustryJobsColumnSettingsList(1) = New Setting("TimeToComplete", CStr(SentSettings.TimeToComplete))
            IndustryJobsColumnSettingsList(2) = New Setting("Activity", CStr(SentSettings.Activity))
            IndustryJobsColumnSettingsList(3) = New Setting("Status", CStr(SentSettings.Status))
            IndustryJobsColumnSettingsList(4) = New Setting("StartTime", CStr(SentSettings.StartTime))
            IndustryJobsColumnSettingsList(5) = New Setting("EndTime", CStr(SentSettings.EndTime))
            IndustryJobsColumnSettingsList(6) = New Setting("CompletionTime", CStr(SentSettings.CompletionTime))
            IndustryJobsColumnSettingsList(7) = New Setting("Blueprint", CStr(SentSettings.Blueprint))
            IndustryJobsColumnSettingsList(8) = New Setting("OutputItem", CStr(SentSettings.OutputItem))
            IndustryJobsColumnSettingsList(9) = New Setting("OutputItemType", CStr(SentSettings.OutputItemType))
            IndustryJobsColumnSettingsList(10) = New Setting("InstallSystem", CStr(SentSettings.InstallSystem))
            IndustryJobsColumnSettingsList(11) = New Setting("InstallRegion", CStr(SentSettings.InstallRegion))
            IndustryJobsColumnSettingsList(12) = New Setting("LicensedRuns", CStr(SentSettings.LicensedRuns))
            IndustryJobsColumnSettingsList(13) = New Setting("Runs", CStr(SentSettings.Runs))
            IndustryJobsColumnSettingsList(14) = New Setting("SuccessfulRuns", CStr(SentSettings.SuccessfulRuns))
            IndustryJobsColumnSettingsList(15) = New Setting("BlueprintLocation", CStr(SentSettings.BlueprintLocation))
            IndustryJobsColumnSettingsList(16) = New Setting("OutputLocation", CStr(SentSettings.OutputLocation))

            IndustryJobsColumnSettingsList(17) = New Setting("JobStateWidth", CStr(SentSettings.JobStateWidth))
            IndustryJobsColumnSettingsList(18) = New Setting("TimeToCompleteWidth", CStr(SentSettings.TimeToCompleteWidth))
            IndustryJobsColumnSettingsList(19) = New Setting("ActivityWidth", CStr(SentSettings.ActivityWidth))
            IndustryJobsColumnSettingsList(20) = New Setting("StatusWidth", CStr(SentSettings.StatusWidth))
            IndustryJobsColumnSettingsList(21) = New Setting("StartTimeWidth", CStr(SentSettings.StartTimeWidth))
            IndustryJobsColumnSettingsList(22) = New Setting("EndTimeWidth", CStr(SentSettings.EndTimeWidth))
            IndustryJobsColumnSettingsList(23) = New Setting("CompletionTimeWidth", CStr(SentSettings.CompletionTimeWidth))
            IndustryJobsColumnSettingsList(24) = New Setting("BlueprintWidth", CStr(SentSettings.BlueprintWidth))
            IndustryJobsColumnSettingsList(25) = New Setting("OutputItemWidth", CStr(SentSettings.OutputItemWidth))
            IndustryJobsColumnSettingsList(26) = New Setting("OutputItemTypeWidth", CStr(SentSettings.OutputItemTypeWidth))
            IndustryJobsColumnSettingsList(27) = New Setting("InstallSystemWidth", CStr(SentSettings.InstallSystemWidth))
            IndustryJobsColumnSettingsList(28) = New Setting("InstallRegionWidth", CStr(SentSettings.InstallRegionWidth))
            IndustryJobsColumnSettingsList(29) = New Setting("LicensedRunsWidth", CStr(SentSettings.LicensedRunsWidth))
            IndustryJobsColumnSettingsList(30) = New Setting("RunsWidth", CStr(SentSettings.RunsWidth))
            IndustryJobsColumnSettingsList(31) = New Setting("SuccessfulRunsWidth", CStr(SentSettings.SuccessfulRunsWidth))
            IndustryJobsColumnSettingsList(32) = New Setting("BlueprintLocationWidth", CStr(SentSettings.BlueprintLocationWidth))
            IndustryJobsColumnSettingsList(33) = New Setting("OutputLocationWidth", CStr(SentSettings.OutputLocationWidth))

            IndustryJobsColumnSettingsList(34) = New Setting("OrderByColumn", CStr(SentSettings.OrderByColumn))
            IndustryJobsColumnSettingsList(35) = New Setting("ViewJobType", CStr(SentSettings.ViewJobType))
            IndustryJobsColumnSettingsList(36) = New Setting("OrderType", CStr(SentSettings.OrderType))
            IndustryJobsColumnSettingsList(37) = New Setting("JobTimes", CStr(SentSettings.JobTimes))
            IndustryJobsColumnSettingsList(38) = New Setting("SelectedCharacterIDs", CStr(SentSettings.SelectedCharacterIDs))

            IndustryJobsColumnSettingsList(39) = New Setting("InstallerName", CStr(SentSettings.InstallerName))
            IndustryJobsColumnSettingsList(40) = New Setting("InstallerNameWidth", CStr(SentSettings.InstallerNameWidth))

            IndustryJobsColumnSettingsList(41) = New Setting("JobType", CStr(SentSettings.JobType))
            IndustryJobsColumnSettingsList(42) = New Setting("JobTypeWidth", CStr(SentSettings.JobTypeWidth))

            IndustryJobsColumnSettingsList(43) = New Setting("AutoUpdateJobs", CStr(SentSettings.AutoUpdateJobs))

            Call WriteSettingsToFile(SettingsFolder, IndustryJobsColumnSettingsFileName, IndustryJobsColumnSettingsList, IndustryJobsColumnSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Industry Jobs Column Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetIndustryJobsColumnSettings() As IndustryJobsColumnSettings
        Return IndustryJobsColumnSettings
    End Function

#End Region

#Region "Manufacturing Tab Column Settings"

    ' Loads the tab settings
    Public Function LoadManufacturingTabColumnSettings() As ManufacturingTabColumnSettings
        Dim TempSettings As ManufacturingTabColumnSettings = Nothing

        Try
            If FileExists(SettingsFolder, ManufacturingTabColumnSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .ItemCategory = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemCategory", DefaultMTItemCategory))
                    .ItemGroup = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemGroup", DefaultMTItemGroup))
                    .ItemName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemName", DefaultMTItemName))
                    .Owned = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Owned", DefaultMTOwned))
                    .Tech = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Tech", DefaultMTTech))
                    .BPME = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPME", DefaultMTBPME))
                    .BPTE = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTE", DefaultMTBPTE))
                    .Inputs = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Inputs", DefaultMTInputs))
                    .Compared = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Compared", DefaultMTCompared))
                    .TotalRuns = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalRuns", DefaultMTTotalRuns))
                    .SingleInventedBPCRuns = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SingleInventedBPCRuns", DefaultMTSingleInventedBPCRuns))
                    .ProductionLines = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProductionLines", DefaultMTProductionLines))
                    .LaboratoryLines = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "LaboratoryLines", DefaultMTLaboratoryLines))
                    .TotalInventionCost = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalInventionCost", DefaultMTTotalInventionCost))
                    .TotalCopyCost = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCopyCost", DefaultMTTotalCopyCost))
                    .Taxes = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Taxes", DefaultMTTaxes))
                    .BrokerFees = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BrokerFees", DefaultMTBrokerFees))
                    .BPProductionTime = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPProductionTime", DefaultMTBPProductionTime))
                    .TotalProductionTime = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalProductionTime", DefaultMTTotalProductionTime))
                    .CopyTime = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyTime", DefaultMTCopyTime))
                    .InventionTime = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionTime", DefaultMTInventionTime))
                    .ItemMarketPrice = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemMarketPrice", DefaultMTItemMarketPrice))
                    .Profit = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Profit", DefaultMTProfit))
                    .ProfitPercentage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitPercentage", DefaultMTProfitPercentage))
                    .IskperHour = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "IskperHour", DefaultMTIskperHour))
                    .SVR = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVR", DefaultMTSVR))
                    .SVRxIPH = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRxIPH", DefaultMTSVRxIPH))
                    .Volatility = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Volatility", DefaultMTVolatility))
                    .Score = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Score", DefaultMTScore))
                    .RiskProfit = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RiskProfit", DefaultMTRiskProfit))
                    .RiskIPH = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RiskIPH", DefaultMTRiskIPH))
                    .RiskPrice = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Risk Price", DefaultMTRiskPrice))
                    .PriceTrend = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PriceTrend", DefaultMTPriceTrend))
                    .TotalItemsSold = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalItemsSold", DefaultMTTotalItemsSold))
                    .TotalOrdersFilled = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalOrdersFilled", DefaultMTTotalOrdersFilled))
                    .AvgItemsperOrder = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "AvgItemsperOrder", DefaultMTAvgItemsperOrder))
                    .CurrentSellOrders = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentSellOrders", DefaultMTCurrentSellOrders))
                    .CurrentBuyOrders = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentBuyOrders", DefaultMTCurrentBuyOrders))
                    .ItemsinProduction = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinProduction", DefaultMTItemsinProduction))
                    .ItemsinStock = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinStock", DefaultMTItemsinStock))
                    .TotalCost = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCost", DefaultMTTotalCost))
                    .BaseJobCost = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BaseJobCost", DefaultMTBaseJobCost))
                    .NumBPs = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "NumBPs", DefaultMTNumBPs))
                    .InventionChance = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionChance", DefaultMTInventionChance))
                    .BPType = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPType", DefaultMTBPType))
                    .Race = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Race", DefaultMTRace))
                    .VolumeperItem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "VolumeperItem", DefaultMTVolumeperItem))
                    .TotalVolume = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalVolume", DefaultMTTotalVolume))
                    .PortionSize = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PortionSize", DefaultMTPortionSize))
                    .ManufacturingJobFee = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingJobFee", DefaultMTManufacturingJobFee))
                    .ManufacturingFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityName", DefaultMTManufacturingFacilityName))
                    .ManufacturingFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystem", DefaultMTManufacturingFacilitySystem))
                    .ManufacturingFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityRegion", DefaultMTManufacturingFacilityRegion))
                    .ManufacturingFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemIndex", DefaultMTManufacturingFacilitySystemIndex))
                    .ManufacturingFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTax", DefaultMTManufacturingFacilityTax))
                    .ManufacturingFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityMEBonus", DefaultMTManufacturingFacilityMEBonus))
                    .ManufacturingFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTEBonus", DefaultMTManufacturingFacilityTEBonus))
                    .ManufacturingFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityUsage", DefaultMTManufacturingFacilityUsage))
                    .ManufacturingFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityFWSystemLevel", DefaultMTManufacturingFacilityFWSystemLevel))
                    .ComponentFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityName", DefaultMTComponentFacilityName))
                    .ComponentFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystem", DefaultMTComponentFacilitySystem))
                    .ComponentFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityRegion", DefaultMTComponentFacilityRegion))
                    .ComponentFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemIndex", DefaultMTComponentFacilitySystemIndex))
                    .ComponentFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTax", DefaultMTComponentFacilityTax))
                    .ComponentFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityMEBonus", DefaultMTComponentFacilityMEBonus))
                    .ComponentFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTEBonus", DefaultMTComponentFacilityTEBonus))
                    .ComponentFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityUsage", DefaultMTComponentFacilityUsage))
                    .ComponentFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityFWSystemLevel", DefaultMTComponentFacilityFWSystemLevel))
                    .CapComponentFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityName", DefaultMTCapComponentFacilityName))
                    .CapComponentFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystem", DefaultMTCapComponentFacilitySystem))
                    .CapComponentFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityRegion", DefaultMTCapComponentFacilityRegion))
                    .CapComponentFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemIndex", DefaultMTCapComponentFacilitySystemIndex))
                    .CapComponentFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTax", DefaultMTCapComponentFacilityTax))
                    .CapComponentFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityMEBonus", DefaultMTCapComponentFacilityMEBonus))
                    .CapComponentFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTEBonus", DefaultMTCapComponentFacilityTEBonus))
                    .CapComponentFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityUsage", DefaultMTCapComponentFacilityUsage))
                    .CapComponentFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityFWSystemLevel", DefaultMTCapComponentFacilityFWSystemLevel))
                    .CopyingFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityName", DefaultMTCopyingFacilityName))
                    .CopyingFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystem", DefaultMTCopyingFacilitySystem))
                    .CopyingFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityRegion", DefaultMTCopyingFacilityRegion))
                    .CopyingFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemIndex", DefaultMTCopyingFacilitySystemIndex))
                    .CopyingFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTax", DefaultMTCopyingFacilityTax))
                    .CopyingFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityMEBonus", DefaultMTCopyingFacilityMEBonus))
                    .CopyingFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTEBonus", DefaultMTCopyingFacilityTEBonus))
                    .CopyingFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityUsage", DefaultMTCopyingFacilityUsage))
                    .CopyingFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityFWSystemLevel", DefaultMTCopyingFacilityFWSystemLevel))
                    .InventionFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityName", DefaultMTInventionFacilityName))
                    .InventionFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystem", DefaultMTInventionFacilitySystem))
                    .InventionFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityRegion", DefaultMTInventionFacilityRegion))
                    .InventionFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemIndex", DefaultMTInventionFacilitySystemIndex))
                    .InventionFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTax", DefaultMTInventionFacilityTax))
                    .InventionFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityMEBonus", DefaultMTInventionFacilityMEBonus))
                    .InventionFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTEBonus", DefaultMTInventionFacilityTEBonus))
                    .InventionFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityUsage", DefaultMTInventionFacilityUsage))
                    .InventionFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityFWSystemLevel", DefaultMTInventionFacilityFWSystemLevel))
                    .ReactionFacilityName = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityName", DefaultMTReactionFacilityName))
                    .ReactionFacilitySystem = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystem", DefaultMTReactionFacilitySystem))
                    .ReactionFacilityRegion = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityRegion", DefaultMTReactionFacilityRegion))
                    .ReactionFacilitySystemIndex = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemIndex", DefaultMTReactionFacilitySystemIndex))
                    .ReactionFacilityTax = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTax", DefaultMTReactionFacilityTax))
                    .ReactionFacilityMEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityMEBonus", DefaultMTReactionFacilityMEBonus))
                    .ReactionFacilityTEBonus = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTEBonus", DefaultMTReactionFacilityTEBonus))
                    .ReactionFacilityUsage = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityUsage", DefaultMTReactionFacilityUsage))
                    .ReactionFacilityFWSystemLevel = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityFWSystemLevel", DefaultMTReactionFacilityFWSystemLevel))

                    .ItemCategoryWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemCategoryWidth", DefaultMTItemCategoryWidth))
                    .ItemGroupWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemGroupWidth", DefaultMTItemGroupWidth))
                    .ItemNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemNameWidth", DefaultMTItemNameWidth))
                    .OwnedWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "OwnedWidth", DefaultMTOwnedWidth))
                    .TechWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TechWidth", DefaultMTTechWidth))
                    .BPMEWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPMEWidth", DefaultMTBPMEWidth))
                    .BPTEWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTEWidth", DefaultMTBPTEWidth))
                    .InputsWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InputsWidth", DefaultMTInputsWidth))
                    .ComparedWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComparedWidth", DefaultMTComparedWidth))
                    .TotalRunsWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalRunsWidth", DefaultMTTotalRunsWidth))
                    .SingleInventedBPCRunsWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SingleInventedBPCRunsWidth", DefaultMTSingleInventedBPCRunsWidth))
                    .ProductionLinesWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProductionLinesWidth", DefaultMTProductionLinesWidth))
                    .LaboratoryLinesWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "LaboratoryLinesWidth", DefaultMTLaboratoryLinesWidth))
                    .TotalInventionCostWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalInventionCostWidth", DefaultMTTotalInventionCostWidth))
                    .TotalCopyCostWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCopyCostWidth", DefaultMTTotalCopyCostWidth))
                    .TaxesWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TaxesWidth", DefaultMTTaxesWidth))
                    .BrokerFeesWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BrokerFeesWidth", DefaultMTBrokerFeesWidth))
                    .BPProductionTimeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPProductionTimeWidth", DefaultMTBPProductionTimeWidth))
                    .TotalProductionTimeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalProductionTimeWidth", DefaultMTTotalProductionTimeWidth))
                    .CopyTimeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyTimeWidth", DefaultMTCopyTimeWidth))
                    .InventionTimeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionTimeWidth", DefaultMTInventionTimeWidth))
                    .ItemMarketPriceWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemMarketPriceWidth", DefaultMTItemMarketPriceWidth))
                    .ProfitWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitWidth", DefaultMTProfitWidth))
                    .ProfitPercentageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitPercentageWidth", DefaultMTProfitPercentageWidth))
                    .IskperHourWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "IskperHourWidth", DefaultMTIskperHourWidth))
                    .SVRWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRWidth", DefaultMTSVRWidth))
                    .SVRxIPHWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRxIPHWidth", DefaultMTSVRxIPHWidth))
                    .VolatilityWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "VolatilityWidth", DefaultMTVolatilityWidth))
                    .ScoreWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ScoreWidth", DefaultMTScoreWidth))
                    .RiskProfitWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RiskProfitWidth", DefaultMTRiskProfitWidth))
                    .RiskIPHWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RiskIPHWidth", DefaultMTRiskIPHWidth))
                    .RiskPriceWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RiskPriceWidth", DefaultMTRiskPriceWidth))
                    .PriceTrendWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PriceTrendWidth", DefaultMTPriceTrendWidth))
                    .TotalItemsSoldWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalItemsSoldWidth", DefaultMTTotalItemsSoldWidth))
                    .TotalOrdersFilledWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalOrdersFilledWidth", DefaultMTTotalOrdersFilledWidth))
                    .AvgItemsperOrderWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "AvgItemsperOrderWidth", DefaultMTAvgItemsperOrderWidth))
                    .CurrentSellOrdersWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentSellOrdersWidth", DefaultMTCurrentSellOrdersWidth))
                    .CurrentBuyOrdersWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentBuyOrdersWidth", DefaultMTCurrentBuyOrdersWidth))
                    .ItemsinProductionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinProductionWidth", DefaultMTItemsinProductionWidth))
                    .ItemsinStockWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinStockWidth", DefaultMTItemsinStockWidth))
                    .TotalCostWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCostWidth", DefaultMTTotalCostWidth))
                    .BaseJobCostWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BaseJobCostWidth", DefaultMTBaseJobCostWidth))
                    .NumBPsWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "NumBPsWidth", DefaultMTNumBPsWidth))
                    .InventionChanceWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionChanceWidth", DefaultMTInventionChanceWidth))
                    .BPTypeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTypeWidth", DefaultMTBPTypeWidth))
                    .RaceWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RaceWidth", DefaultMTRaceWidth))
                    .VolumeperItemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "VolumeperItemWidth", DefaultMTVolumeperItemWidth))
                    .TotalVolumeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalVolumeWidth", DefaultMTTotalVolumeWidth))
                    .PortionSizeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PortionSizeWidth", DefaultMTPortionSizeWidth))
                    .ManufacturingJobFeeWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingJobFeeWidth", DefaultMTManufacturingJobFeeWidth))
                    .ManufacturingFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityNameWidth", DefaultMTManufacturingFacilityNameWidth))
                    .ManufacturingFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemWidth", DefaultMTManufacturingFacilitySystemWidth))
                    .ManufacturingFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityRegionWidth", DefaultMTManufacturingFacilityRegionWidth))
                    .ManufacturingFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemIndexWidth", DefaultMTManufacturingFacilitySystemIndexWidth))
                    .ManufacturingFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTaxWidth", DefaultMTManufacturingFacilityTaxWidth))
                    .ManufacturingFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityMEBonusWidth", DefaultMTManufacturingFacilityMEBonusWidth))
                    .ManufacturingFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTEBonusWidth", DefaultMTManufacturingFacilityTEBonusWidth))
                    .ManufacturingFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityUsageWidth", DefaultMTManufacturingFacilityUsageWidth))
                    .ManufacturingFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityFWSystemLevelWidth", DefaultMTManufacturingFacilityFWSystemLevelWidth))
                    .ComponentFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityNameWidth", DefaultMTComponentFacilityNameWidth))
                    .ComponentFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemWidth", DefaultMTComponentFacilitySystemWidth))
                    .ComponentFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityRegionWidth", DefaultMTComponentFacilityRegionWidth))
                    .ComponentFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemIndexWidth", DefaultMTComponentFacilitySystemIndexWidth))
                    .ComponentFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTaxWidth", DefaultMTComponentFacilityTaxWidth))
                    .ComponentFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityMEBonusWidth", DefaultMTComponentFacilityMEBonusWidth))
                    .ComponentFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTEBonusWidth", DefaultMTComponentFacilityTEBonusWidth))
                    .ComponentFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityUsageWidth", DefaultMTComponentFacilityUsageWidth))
                    .ComponentFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityFWSystemLevelWidth", DefaultMTComponentFacilityFWSystemLevelWidth))
                    .CapComponentFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityNameWidth", DefaultMTCapComponentFacilityNameWidth))
                    .CapComponentFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemWidth", DefaultMTCapComponentFacilitySystemWidth))
                    .CapComponentFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityRegionWidth", DefaultMTCapComponentFacilityRegionWidth))
                    .CapComponentFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemIndexWidth", DefaultMTCapComponentFacilitySystemIndexWidth))
                    .CapComponentFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTaxWidth", DefaultMTCapComponentFacilityTaxWidth))
                    .CapComponentFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityMEBonusWidth", DefaultMTCapComponentFacilityMEBonusWidth))
                    .CapComponentFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTEBonusWidth", DefaultMTCapComponentFacilityTEBonusWidth))
                    .CapComponentFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityUsageWidth", DefaultMTCapComponentFacilityUsageWidth))
                    .CapComponentFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityFWSystemLevelWidth", DefaultMTCapComponentFacilityFWSystemLevelWidth))
                    .CopyingFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityNameWidth", DefaultMTCopyingFacilityNameWidth))
                    .CopyingFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemWidth", DefaultMTCopyingFacilitySystemWidth))
                    .CopyingFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityRegionWidth", DefaultMTCopyingFacilityRegionWidth))
                    .CopyingFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemIndexWidth", DefaultMTCopyingFacilitySystemIndexWidth))
                    .CopyingFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTaxWidth", DefaultMTCopyingFacilityTaxWidth))
                    .CopyingFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityMEBonusWidth", DefaultMTCopyingFacilityMEBonusWidth))
                    .CopyingFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTEBonusWidth", DefaultMTCopyingFacilityTEBonusWidth))
                    .CopyingFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityUsageWidth", DefaultMTCopyingFacilityUsageWidth))
                    .CopyingFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityFWSystemLevelWidth", DefaultMTCopyingFacilityFWSystemLevelWidth))
                    .InventionFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityNameWidth", DefaultMTInventionFacilityNameWidth))
                    .InventionFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemWidth", DefaultMTInventionFacilitySystemWidth))
                    .InventionFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityRegionWidth", DefaultMTInventionFacilityRegionWidth))
                    .InventionFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemIndexWidth", DefaultMTInventionFacilitySystemIndexWidth))
                    .InventionFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTaxWidth", DefaultMTInventionFacilityTaxWidth))
                    .InventionFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityMEBonusWidth", DefaultMTInventionFacilityMEBonusWidth))
                    .InventionFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTEBonusWidth", DefaultMTInventionFacilityTEBonusWidth))
                    .InventionFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityUsageWidth", DefaultMTInventionFacilityUsageWidth))
                    .InventionFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityFWSystemLevelWidth", DefaultMTInventionFacilityFWSystemLevelWidth))
                    .ReactionFacilityNameWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityNameWidth", DefaultMTReactionFacilityNameWidth))
                    .ReactionFacilitySystemWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemWidth", DefaultMTReactionFacilitySystemWidth))
                    .ReactionFacilityRegionWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityRegionWidth", DefaultMTReactionFacilityRegionWidth))
                    .ReactionFacilitySystemIndexWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemIndexWidth", DefaultMTReactionFacilitySystemIndexWidth))
                    .ReactionFacilityTaxWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTaxWidth", DefaultMTReactionFacilityTaxWidth))
                    .ReactionFacilityMEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityMEBonusWidth", DefaultMTReactionFacilityMEBonusWidth))
                    .ReactionFacilityTEBonusWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTEBonusWidth", DefaultMTReactionFacilityTEBonusWidth))
                    .ReactionFacilityUsageWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityUsageWidth", DefaultMTReactionFacilityUsageWidth))
                    .ReactionFacilityFWSystemLevelWidth = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityFWSystemLevelWidth", DefaultMTReactionFacilityFWSystemLevelWidth))

                    .OrderByColumn = CInt(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeInteger, ManufacturingTabColumnSettingsFileName, "OrderByColumn", DefaultMTOrderByColumn))
                    .OrderType = CStr(GetSettingValue(SettingsFolder, ManufacturingTabColumnSettingsFileName, SettingTypes.TypeString, ManufacturingTabColumnSettingsFileName, "OrderType", DefaultMTOrderType))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultManufacturingTabColumnSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Industry Jobs Column Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultManufacturingTabColumnSettings()
        End Try

        ' Save them locally and then export
        ManufacturingTabColumnSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultManufacturingTabColumnSettings() As ManufacturingTabColumnSettings
        Dim LocalSettings As ManufacturingTabColumnSettings

        With LocalSettings
            .ItemCategory = DefaultMTItemCategory
            .ItemGroup = DefaultMTItemGroup
            .ItemName = DefaultMTItemName
            .Owned = DefaultMTOwned
            .Tech = DefaultMTTech
            .BPME = DefaultMTBPME
            .BPTE = DefaultMTBPTE
            .Inputs = DefaultMTInputs
            .Compared = DefaultMTCompared
            .TotalRuns = DefaultMTTotalRuns
            .SingleInventedBPCRuns = DefaultMTSingleInventedBPCRuns
            .ProductionLines = DefaultMTProductionLines
            .LaboratoryLines = DefaultMTLaboratoryLines
            .TotalInventionCost = DefaultMTTotalInventionCost
            .TotalCopyCost = DefaultMTTotalCopyCost
            .Taxes = DefaultMTTaxes
            .BrokerFees = DefaultMTBrokerFees
            .BPProductionTime = DefaultMTBPProductionTime
            .TotalProductionTime = DefaultMTTotalProductionTime
            .CopyTime = DefaultMTCopyTime
            .InventionTime = DefaultMTInventionTime
            .ItemMarketPrice = DefaultMTItemMarketPrice
            .Profit = DefaultMTProfit
            .ProfitPercentage = DefaultMTProfitPercentage
            .IskperHour = DefaultMTIskperHour
            .SVR = DefaultMTSVR
            .SVRxIPH = DefaultMTSVRxIPH
            .Score = DefaultMTScore
            .RiskProfit = DefaultMTRiskProfit
            .RiskIPH = DefaultMTRiskIPH
            .RiskPrice = DefaultMTRiskPrice
            .Volatility = DefaultMTVolatility
            .PriceTrend = DefaultMTPriceTrend
            .TotalItemsSold = DefaultMTTotalItemsSold
            .TotalOrdersFilled = DefaultMTTotalOrdersFilled
            .AvgItemsperOrder = DefaultMTAvgItemsperOrder
            .CurrentSellOrders = DefaultMTCurrentSellOrders
            .CurrentBuyOrders = DefaultMTCurrentBuyOrders
            .ItemsinProduction = DefaultMTItemsinProduction
            .ItemsinStock = DefaultMTItemsinStock
            .TotalCost = DefaultMTTotalCost
            .BaseJobCost = DefaultMTBaseJobCost
            .NumBPs = DefaultMTNumBPs
            .InventionChance = DefaultMTInventionChance
            .BPType = DefaultMTBPType
            .Race = DefaultMTRace
            .VolumeperItem = DefaultMTVolumeperItem
            .TotalVolume = DefaultMTTotalVolume
            .PortionSize = DefaultMTPortionSize
            .ManufacturingJobFee = DefaultMTManufacturingJobFee
            .ManufacturingFacilityName = DefaultMTManufacturingFacilityName
            .ManufacturingFacilitySystem = DefaultMTManufacturingFacilitySystem
            .ManufacturingFacilityRegion = DefaultMTManufacturingFacilityRegion
            .ManufacturingFacilitySystemIndex = DefaultMTManufacturingFacilitySystemIndex
            .ManufacturingFacilityTax = DefaultMTManufacturingFacilityTax
            .ManufacturingFacilityMEBonus = DefaultMTManufacturingFacilityMEBonus
            .ManufacturingFacilityTEBonus = DefaultMTManufacturingFacilityTEBonus
            .ManufacturingFacilityUsage = DefaultMTManufacturingFacilityUsage
            .ManufacturingFacilityFWSystemLevel = DefaultMTManufacturingFacilityFWSystemLevel
            .ComponentFacilityName = DefaultMTComponentFacilityName
            .ComponentFacilitySystem = DefaultMTComponentFacilitySystem
            .ComponentFacilityRegion = DefaultMTComponentFacilityRegion
            .ComponentFacilitySystemIndex = DefaultMTComponentFacilitySystemIndex
            .ComponentFacilityTax = DefaultMTComponentFacilityTax
            .ComponentFacilityMEBonus = DefaultMTComponentFacilityMEBonus
            .ComponentFacilityTEBonus = DefaultMTComponentFacilityTEBonus
            .ComponentFacilityUsage = DefaultMTComponentFacilityUsage
            .ComponentFacilityFWSystemLevel = DefaultMTComponentFacilityFWSystemLevel
            .CapComponentFacilityName = DefaultMTCapComponentFacilityName
            .CapComponentFacilitySystem = DefaultMTCapComponentFacilitySystem
            .CapComponentFacilityRegion = DefaultMTCapComponentFacilityRegion
            .CapComponentFacilitySystemIndex = DefaultMTCapComponentFacilitySystemIndex
            .CapComponentFacilityTax = DefaultMTCapComponentFacilityTax
            .CapComponentFacilityMEBonus = DefaultMTCapComponentFacilityMEBonus
            .CapComponentFacilityTEBonus = DefaultMTCapComponentFacilityTEBonus
            .CapComponentFacilityUsage = DefaultMTCapComponentFacilityUsage
            .CapComponentFacilityFWSystemLevel = DefaultMTCapComponentFacilityFWSystemLevel
            .CopyingFacilityName = DefaultMTCopyingFacilityName
            .CopyingFacilitySystem = DefaultMTCopyingFacilitySystem
            .CopyingFacilityRegion = DefaultMTCopyingFacilityRegion
            .CopyingFacilitySystemIndex = DefaultMTCopyingFacilitySystemIndex
            .CopyingFacilityTax = DefaultMTCopyingFacilityTax
            .CopyingFacilityMEBonus = DefaultMTCopyingFacilityMEBonus
            .CopyingFacilityTEBonus = DefaultMTCopyingFacilityTEBonus
            .CopyingFacilityUsage = DefaultMTCopyingFacilityUsage
            .CopyingFacilityFWSystemLevel = DefaultMTCopyingFacilityFWSystemLevel
            .InventionFacilityName = DefaultMTInventionFacilityName
            .InventionFacilitySystem = DefaultMTInventionFacilitySystem
            .InventionFacilityRegion = DefaultMTInventionFacilityRegion
            .InventionFacilitySystemIndex = DefaultMTInventionFacilitySystemIndex
            .InventionFacilityTax = DefaultMTInventionFacilityTax
            .InventionFacilityMEBonus = DefaultMTInventionFacilityMEBonus
            .InventionFacilityTEBonus = DefaultMTInventionFacilityTEBonus
            .InventionFacilityUsage = DefaultMTInventionFacilityUsage
            .InventionFacilityFWSystemLevel = DefaultMTInventionFacilityFWSystemLevel
            .ReactionFacilityName = DefaultMTReactionFacilityName
            .ReactionFacilitySystem = DefaultMTReactionFacilitySystem
            .ReactionFacilityRegion = DefaultMTReactionFacilityRegion
            .ReactionFacilitySystemIndex = DefaultMTReactionFacilitySystemIndex
            .ReactionFacilityTax = DefaultMTReactionFacilityTax
            .ReactionFacilityMEBonus = DefaultMTReactionFacilityMEBonus
            .ReactionFacilityTEBonus = DefaultMTReactionFacilityTEBonus
            .ReactionFacilityUsage = DefaultMTReactionFacilityUsage
            .ReactionFacilityFWSystemLevel = DefaultMTReactionFacilityFWSystemLevel

            .ItemCategoryWidth = DefaultMTItemCategoryWidth
            .ItemGroupWidth = DefaultMTItemGroupWidth
            .ItemNameWidth = DefaultMTItemNameWidth
            .OwnedWidth = DefaultMTOwnedWidth
            .TechWidth = DefaultMTTechWidth
            .BPMEWidth = DefaultMTBPMEWidth
            .BPTEWidth = DefaultMTBPTEWidth
            .InputsWidth = DefaultMTInputsWidth
            .ComparedWidth = DefaultMTComparedWidth
            .TotalRunsWidth = DefaultMTTotalRunsWidth
            .SingleInventedBPCRunsWidth = DefaultMTSingleInventedBPCRunsWidth
            .ProductionLinesWidth = DefaultMTProductionLinesWidth
            .LaboratoryLinesWidth = DefaultMTLaboratoryLinesWidth
            .TotalInventionCostWidth = DefaultMTTotalInventionCostWidth
            .TotalCopyCostWidth = DefaultMTTotalCopyCostWidth
            .TaxesWidth = DefaultMTTaxesWidth
            .BrokerFeesWidth = DefaultMTBrokerFeesWidth
            .BPProductionTimeWidth = DefaultMTBPProductionTimeWidth
            .TotalProductionTimeWidth = DefaultMTTotalProductionTimeWidth
            .CopyTimeWidth = DefaultMTCopyTimeWidth
            .InventionTimeWidth = DefaultMTInventionTimeWidth
            .ItemMarketPriceWidth = DefaultMTItemMarketPriceWidth
            .ProfitWidth = DefaultMTProfitWidth
            .ProfitPercentageWidth = DefaultMTProfitPercentageWidth
            .IskperHourWidth = DefaultMTIskperHourWidth
            .SVRWidth = DefaultMTSVRWidth
            .SVRxIPHWidth = DefaultMTSVRxIPHWidth
            .ScoreWidth = DefaultMTScoreWidth
            .RiskProfitWidth = DefaultMTRiskProfitWidth
            .RiskIPHWidth = DefaultMTRiskIPHWidth
            .RiskPriceWidth = DefaultMTRiskPriceWidth
            .VolatilityWidth = DefaultMTVolatilityWidth
            .PriceTrendWidth = DefaultMTPriceTrendWidth
            .TotalItemsSoldWidth = DefaultMTTotalItemsSoldWidth
            .TotalOrdersFilledWidth = DefaultMTTotalOrdersFilledWidth
            .AvgItemsperOrderWidth = DefaultMTAvgItemsperOrderWidth
            .CurrentSellOrdersWidth = DefaultMTCurrentSellOrdersWidth
            .CurrentBuyOrdersWidth = DefaultMTCurrentBuyOrdersWidth
            .ItemsinProductionWidth = DefaultMTItemsinProductionWidth
            .ItemsinStockWidth = DefaultMTItemsinStockWidth
            .TotalCostWidth = DefaultMTTotalCostWidth
            .BaseJobCostWidth = DefaultMTBaseJobCostWidth
            .NumBPsWidth = DefaultMTNumBPsWidth
            .InventionChanceWidth = DefaultMTInventionChanceWidth
            .BPTypeWidth = DefaultMTBPTypeWidth
            .RaceWidth = DefaultMTRaceWidth
            .VolumeperItemWidth = DefaultMTVolumeperItemWidth
            .TotalVolumeWidth = DefaultMTTotalVolumeWidth
            .PortionSizeWidth = DefaultMTPortionSizeWidth
            .ManufacturingJobFeeWidth = DefaultMTManufacturingJobFeeWidth
            .ManufacturingFacilityNameWidth = DefaultMTManufacturingFacilityNameWidth
            .ManufacturingFacilitySystemWidth = DefaultMTManufacturingFacilitySystemWidth
            .ManufacturingFacilityRegionWidth = DefaultMTManufacturingFacilityRegionWidth
            .ManufacturingFacilitySystemIndexWidth = DefaultMTManufacturingFacilitySystemIndexWidth
            .ManufacturingFacilityTaxWidth = DefaultMTManufacturingFacilityTaxWidth
            .ManufacturingFacilityMEBonusWidth = DefaultMTManufacturingFacilityMEBonusWidth
            .ManufacturingFacilityTEBonusWidth = DefaultMTManufacturingFacilityTEBonusWidth
            .ManufacturingFacilityUsageWidth = DefaultMTManufacturingFacilityUsageWidth
            .ManufacturingFacilityFWSystemLevelWidth = DefaultMTManufacturingFacilityFWSystemLevelWidth
            .ComponentFacilityNameWidth = DefaultMTComponentFacilityNameWidth
            .ComponentFacilitySystemWidth = DefaultMTComponentFacilitySystemWidth
            .ComponentFacilityRegionWidth = DefaultMTComponentFacilityRegionWidth
            .ComponentFacilitySystemIndexWidth = DefaultMTComponentFacilitySystemIndexWidth
            .ComponentFacilityTaxWidth = DefaultMTComponentFacilityTaxWidth
            .ComponentFacilityMEBonusWidth = DefaultMTComponentFacilityMEBonusWidth
            .ComponentFacilityTEBonusWidth = DefaultMTComponentFacilityTEBonusWidth
            .ComponentFacilityUsageWidth = DefaultMTComponentFacilityUsageWidth
            .ComponentFacilityFWSystemLevelWidth = DefaultMTComponentFacilityFWSystemLevelWidth
            .CapComponentFacilityNameWidth = DefaultMTCapComponentFacilityNameWidth
            .CapComponentFacilitySystemWidth = DefaultMTCapComponentFacilitySystemWidth
            .CapComponentFacilityRegionWidth = DefaultMTCapComponentFacilityRegionWidth
            .CapComponentFacilitySystemIndexWidth = DefaultMTCapComponentFacilitySystemIndexWidth
            .CapComponentFacilityTaxWidth = DefaultMTCapComponentFacilityTaxWidth
            .CapComponentFacilityMEBonusWidth = DefaultMTCapComponentFacilityMEBonusWidth
            .CapComponentFacilityTEBonusWidth = DefaultMTCapComponentFacilityTEBonusWidth
            .CapComponentFacilityUsageWidth = DefaultMTCapComponentFacilityUsageWidth
            .CapComponentFacilityFWSystemLevelWidth = DefaultMTCapComponentFacilityFWSystemLevelWidth
            .CopyingFacilityNameWidth = DefaultMTCopyingFacilityNameWidth
            .CopyingFacilitySystemWidth = DefaultMTCopyingFacilitySystemWidth
            .CopyingFacilityRegionWidth = DefaultMTCopyingFacilityRegionWidth
            .CopyingFacilitySystemIndexWidth = DefaultMTCopyingFacilitySystemIndexWidth
            .CopyingFacilityTaxWidth = DefaultMTCopyingFacilityTaxWidth
            .CopyingFacilityMEBonusWidth = DefaultMTCopyingFacilityMEBonusWidth
            .CopyingFacilityTEBonusWidth = DefaultMTCopyingFacilityTEBonusWidth
            .CopyingFacilityUsageWidth = DefaultMTCopyingFacilityUsageWidth
            .CopyingFacilityFWSystemLevelWidth = DefaultMTCopyingFacilityFWSystemLevelWidth
            .InventionFacilityNameWidth = DefaultMTInventionFacilityNameWidth
            .InventionFacilitySystemWidth = DefaultMTInventionFacilitySystemWidth
            .InventionFacilityRegionWidth = DefaultMTInventionFacilityRegionWidth
            .InventionFacilitySystemIndexWidth = DefaultMTInventionFacilitySystemIndexWidth
            .InventionFacilityTaxWidth = DefaultMTInventionFacilityTaxWidth
            .InventionFacilityMEBonusWidth = DefaultMTInventionFacilityMEBonusWidth
            .InventionFacilityTEBonusWidth = DefaultMTInventionFacilityTEBonusWidth
            .InventionFacilityUsageWidth = DefaultMTInventionFacilityUsageWidth
            .InventionFacilityFWSystemLevelWidth = DefaultMTInventionFacilityFWSystemLevelWidth
            .ReactionFacilityNameWidth = DefaultMTReactionFacilityNameWidth
            .ReactionFacilitySystemWidth = DefaultMTReactionFacilitySystemWidth
            .ReactionFacilityRegionWidth = DefaultMTReactionFacilityRegionWidth
            .ReactionFacilitySystemIndexWidth = DefaultMTReactionFacilitySystemIndexWidth
            .ReactionFacilityTaxWidth = DefaultMTReactionFacilityTaxWidth
            .ReactionFacilityMEBonusWidth = DefaultMTReactionFacilityMEBonusWidth
            .ReactionFacilityTEBonusWidth = DefaultMTReactionFacilityTEBonusWidth
            .ReactionFacilityUsageWidth = DefaultMTReactionFacilityUsageWidth
            .ReactionFacilityFWSystemLevelWidth = DefaultMTReactionFacilityFWSystemLevelWidth

            .OrderByColumn = DefaultMTOrderByColumn
            .OrderType = DefaultMTOrderType

        End With

        ' save locally
        ManufacturingTabColumnSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveManufacturingTabColumnSettings(SentSettings As ManufacturingTabColumnSettings)
        Dim ManufacturingTabColumnSettingsList(209) As Setting

        Try
            ManufacturingTabColumnSettingsList(0) = New Setting("ItemCategory", CStr(SentSettings.ItemCategory))
            ManufacturingTabColumnSettingsList(1) = New Setting("ItemGroup", CStr(SentSettings.ItemGroup))
            ManufacturingTabColumnSettingsList(2) = New Setting("ItemName", CStr(SentSettings.ItemName))
            ManufacturingTabColumnSettingsList(3) = New Setting("Owned", CStr(SentSettings.Owned))
            ManufacturingTabColumnSettingsList(4) = New Setting("Tech", CStr(SentSettings.Tech))
            ManufacturingTabColumnSettingsList(5) = New Setting("BPME", CStr(SentSettings.BPME))
            ManufacturingTabColumnSettingsList(6) = New Setting("BPTE", CStr(SentSettings.BPTE))
            ManufacturingTabColumnSettingsList(7) = New Setting("Inputs", CStr(SentSettings.Inputs))
            ManufacturingTabColumnSettingsList(8) = New Setting("Compared", CStr(SentSettings.Compared))
            ManufacturingTabColumnSettingsList(9) = New Setting("TotalRuns", CStr(SentSettings.TotalRuns))
            ManufacturingTabColumnSettingsList(10) = New Setting("SingleInventedBPCRuns", CStr(SentSettings.SingleInventedBPCRuns))
            ManufacturingTabColumnSettingsList(11) = New Setting("ProductionLines", CStr(SentSettings.ProductionLines))
            ManufacturingTabColumnSettingsList(12) = New Setting("LaboratoryLines", CStr(SentSettings.LaboratoryLines))
            ManufacturingTabColumnSettingsList(13) = New Setting("TotalInventionCost", CStr(SentSettings.TotalInventionCost))
            ManufacturingTabColumnSettingsList(14) = New Setting("TotalCopyCost", CStr(SentSettings.TotalCopyCost))
            ManufacturingTabColumnSettingsList(15) = New Setting("Taxes", CStr(SentSettings.Taxes))
            ManufacturingTabColumnSettingsList(16) = New Setting("BrokerFees", CStr(SentSettings.BrokerFees))
            ManufacturingTabColumnSettingsList(17) = New Setting("BPProductionTime", CStr(SentSettings.BPProductionTime))
            ManufacturingTabColumnSettingsList(18) = New Setting("TotalProductionTime", CStr(SentSettings.TotalProductionTime))
            ManufacturingTabColumnSettingsList(19) = New Setting("CopyTime", CStr(SentSettings.CopyTime))
            ManufacturingTabColumnSettingsList(20) = New Setting("InventionTime", CStr(SentSettings.InventionTime))
            ManufacturingTabColumnSettingsList(21) = New Setting("ItemMarketPrice", CStr(SentSettings.ItemMarketPrice))
            ManufacturingTabColumnSettingsList(22) = New Setting("Profit", CStr(SentSettings.Profit))
            ManufacturingTabColumnSettingsList(23) = New Setting("ProfitPercentage", CStr(SentSettings.ProfitPercentage))
            ManufacturingTabColumnSettingsList(24) = New Setting("IskperHour", CStr(SentSettings.IskperHour))
            ManufacturingTabColumnSettingsList(25) = New Setting("SVR", CStr(SentSettings.SVR))
            ManufacturingTabColumnSettingsList(26) = New Setting("SVRxIPH", CStr(SentSettings.SVRxIPH))
            ManufacturingTabColumnSettingsList(27) = New Setting("PriceTrend", CStr(SentSettings.PriceTrend))
            ManufacturingTabColumnSettingsList(28) = New Setting("TotalItemsSold", CStr(SentSettings.TotalItemsSold))
            ManufacturingTabColumnSettingsList(29) = New Setting("TotalOrdersFilled", CStr(SentSettings.TotalOrdersFilled))
            ManufacturingTabColumnSettingsList(30) = New Setting("AvgItemsperOrder", CStr(SentSettings.AvgItemsperOrder))
            ManufacturingTabColumnSettingsList(31) = New Setting("CurrentSellOrders", CStr(SentSettings.CurrentSellOrders))
            ManufacturingTabColumnSettingsList(32) = New Setting("CurrentBuyOrders", CStr(SentSettings.CurrentBuyOrders))
            ManufacturingTabColumnSettingsList(33) = New Setting("ItemsinProduction", CStr(SentSettings.ItemsinProduction))
            ManufacturingTabColumnSettingsList(34) = New Setting("ItemsinStock", CStr(SentSettings.ItemsinStock))
            ManufacturingTabColumnSettingsList(35) = New Setting("TotalCost", CStr(SentSettings.TotalCost))
            ManufacturingTabColumnSettingsList(36) = New Setting("BaseJobCost", CStr(SentSettings.BaseJobCost))
            ManufacturingTabColumnSettingsList(37) = New Setting("NumBPs", CStr(SentSettings.NumBPs))
            ManufacturingTabColumnSettingsList(38) = New Setting("InventionChance", CStr(SentSettings.InventionChance))
            ManufacturingTabColumnSettingsList(39) = New Setting("BPType", CStr(SentSettings.BPType))
            ManufacturingTabColumnSettingsList(40) = New Setting("Race", CStr(SentSettings.Race))
            ManufacturingTabColumnSettingsList(41) = New Setting("VolumeperItem", CStr(SentSettings.VolumeperItem))
            ManufacturingTabColumnSettingsList(42) = New Setting("TotalVolume", CStr(SentSettings.TotalVolume))
            ManufacturingTabColumnSettingsList(43) = New Setting("PortionSize", CStr(SentSettings.PortionSize))
            ManufacturingTabColumnSettingsList(44) = New Setting("ManufacturingJobFee", CStr(SentSettings.ManufacturingJobFee))
            ManufacturingTabColumnSettingsList(45) = New Setting("ManufacturingFacilityName", CStr(SentSettings.ManufacturingFacilityName))
            ManufacturingTabColumnSettingsList(46) = New Setting("ManufacturingFacilitySystem", CStr(SentSettings.ManufacturingFacilitySystem))
            ManufacturingTabColumnSettingsList(47) = New Setting("ManufacturingFacilityRegion", CStr(SentSettings.ManufacturingFacilityRegion))
            ManufacturingTabColumnSettingsList(48) = New Setting("ManufacturingFacilitySystemIndex", CStr(SentSettings.ManufacturingFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(49) = New Setting("ManufacturingFacilityTax", CStr(SentSettings.ManufacturingFacilityTax))
            ManufacturingTabColumnSettingsList(50) = New Setting("ManufacturingFacilityMEBonus", CStr(SentSettings.ManufacturingFacilityMEBonus))
            ManufacturingTabColumnSettingsList(51) = New Setting("ManufacturingFacilityTEBonus", CStr(SentSettings.ManufacturingFacilityTEBonus))
            ManufacturingTabColumnSettingsList(52) = New Setting("ManufacturingFacilityUsage", CStr(SentSettings.ManufacturingFacilityUsage))
            ManufacturingTabColumnSettingsList(53) = New Setting("ManufacturingFacilityFWSystemLevel", CStr(SentSettings.ManufacturingFacilityFWSystemLevel))
            ManufacturingTabColumnSettingsList(54) = New Setting("ComponentFacilityName", CStr(SentSettings.ComponentFacilityName))
            ManufacturingTabColumnSettingsList(55) = New Setting("ComponentFacilitySystem", CStr(SentSettings.ComponentFacilitySystem))
            ManufacturingTabColumnSettingsList(56) = New Setting("ComponentFacilityRegion", CStr(SentSettings.ComponentFacilityRegion))
            ManufacturingTabColumnSettingsList(57) = New Setting("ComponentFacilitySystemIndex", CStr(SentSettings.ComponentFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(58) = New Setting("ComponentFacilityTax", CStr(SentSettings.ComponentFacilityTax))
            ManufacturingTabColumnSettingsList(59) = New Setting("ComponentFacilityMEBonus", CStr(SentSettings.ComponentFacilityMEBonus))
            ManufacturingTabColumnSettingsList(60) = New Setting("ComponentFacilityTEBonus", CStr(SentSettings.ComponentFacilityTEBonus))
            ManufacturingTabColumnSettingsList(61) = New Setting("ComponentFacilityUsage", CStr(SentSettings.ComponentFacilityUsage))
            ManufacturingTabColumnSettingsList(62) = New Setting("ComponentFacilityFWSystemLevel", CStr(SentSettings.ComponentFacilityFWSystemLevel))
            ManufacturingTabColumnSettingsList(63) = New Setting("CapComponentFacilityName", CStr(SentSettings.CapComponentFacilityName))
            ManufacturingTabColumnSettingsList(64) = New Setting("CapComponentFacilitySystem", CStr(SentSettings.CapComponentFacilitySystem))
            ManufacturingTabColumnSettingsList(65) = New Setting("CapComponentFacilityRegion", CStr(SentSettings.CapComponentFacilityRegion))
            ManufacturingTabColumnSettingsList(66) = New Setting("CapComponentFacilitySystemIndex", CStr(SentSettings.CapComponentFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(67) = New Setting("CapComponentFacilityTax", CStr(SentSettings.CapComponentFacilityTax))
            ManufacturingTabColumnSettingsList(68) = New Setting("CapComponentFacilityMEBonus", CStr(SentSettings.CapComponentFacilityMEBonus))
            ManufacturingTabColumnSettingsList(69) = New Setting("CapComponentFacilityTEBonus", CStr(SentSettings.CapComponentFacilityTEBonus))
            ManufacturingTabColumnSettingsList(70) = New Setting("CapComponentFacilityUsage", CStr(SentSettings.CapComponentFacilityUsage))
            ManufacturingTabColumnSettingsList(71) = New Setting("CapComponentFacilityFWSystemLevel", CStr(SentSettings.CapComponentFacilityFWSystemLevel))
            ManufacturingTabColumnSettingsList(72) = New Setting("CopyingFacilityName", CStr(SentSettings.CopyingFacilityName))
            ManufacturingTabColumnSettingsList(73) = New Setting("CopyingFacilitySystem", CStr(SentSettings.CopyingFacilitySystem))
            ManufacturingTabColumnSettingsList(74) = New Setting("CopyingFacilityRegion", CStr(SentSettings.CopyingFacilityRegion))
            ManufacturingTabColumnSettingsList(75) = New Setting("CopyingFacilitySystemIndex", CStr(SentSettings.CopyingFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(76) = New Setting("CopyingFacilityTax", CStr(SentSettings.CopyingFacilityTax))
            ManufacturingTabColumnSettingsList(77) = New Setting("CopyingFacilityMEBonus", CStr(SentSettings.CopyingFacilityMEBonus))
            ManufacturingTabColumnSettingsList(78) = New Setting("CopyingFacilityTEBonus", CStr(SentSettings.CopyingFacilityTEBonus))
            ManufacturingTabColumnSettingsList(79) = New Setting("CopyingFacilityUsage", CStr(SentSettings.CopyingFacilityUsage))
            ManufacturingTabColumnSettingsList(80) = New Setting("CopyingFacilityFWSystemLevel", CStr(SentSettings.CopyingFacilityFWSystemLevel))
            ManufacturingTabColumnSettingsList(81) = New Setting("InventionFacilityName", CStr(SentSettings.InventionFacilityName))
            ManufacturingTabColumnSettingsList(82) = New Setting("InventionFacilitySystem", CStr(SentSettings.InventionFacilitySystem))
            ManufacturingTabColumnSettingsList(83) = New Setting("InventionFacilityRegion", CStr(SentSettings.InventionFacilityRegion))
            ManufacturingTabColumnSettingsList(84) = New Setting("InventionFacilitySystemIndex", CStr(SentSettings.InventionFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(85) = New Setting("InventionFacilityTax", CStr(SentSettings.InventionFacilityTax))
            ManufacturingTabColumnSettingsList(86) = New Setting("InventionFacilityMEBonus", CStr(SentSettings.InventionFacilityMEBonus))
            ManufacturingTabColumnSettingsList(87) = New Setting("InventionFacilityTEBonus", CStr(SentSettings.InventionFacilityTEBonus))
            ManufacturingTabColumnSettingsList(88) = New Setting("InventionFacilityUsage", CStr(SentSettings.InventionFacilityUsage))
            ManufacturingTabColumnSettingsList(89) = New Setting("InventionFacilityFWSystemLevel", CStr(SentSettings.InventionFacilityFWSystemLevel))
            ManufacturingTabColumnSettingsList(90) = New Setting("ReactionFacilityName", CStr(SentSettings.ReactionFacilityName))
            ManufacturingTabColumnSettingsList(91) = New Setting("ReactionFacilitySystem", CStr(SentSettings.ReactionFacilitySystem))
            ManufacturingTabColumnSettingsList(92) = New Setting("ReactionFacilityRegion", CStr(SentSettings.ReactionFacilityRegion))
            ManufacturingTabColumnSettingsList(93) = New Setting("ReactionFacilitySystemIndex", CStr(SentSettings.ReactionFacilitySystemIndex))
            ManufacturingTabColumnSettingsList(94) = New Setting("ReactionFacilityTax", CStr(SentSettings.ReactionFacilityTax))
            ManufacturingTabColumnSettingsList(95) = New Setting("ReactionFacilityMEBonus", CStr(SentSettings.ReactionFacilityMEBonus))
            ManufacturingTabColumnSettingsList(96) = New Setting("ReactionFacilityTEBonus", CStr(SentSettings.ReactionFacilityTEBonus))
            ManufacturingTabColumnSettingsList(97) = New Setting("ReactionFacilityUsage", CStr(SentSettings.ReactionFacilityUsage))
            ManufacturingTabColumnSettingsList(98) = New Setting("ReactionFacilityFWSystemLevel", CStr(SentSettings.ReactionFacilityFWSystemLevel))

            ManufacturingTabColumnSettingsList(99) = New Setting("ItemCategoryWidth", CStr(SentSettings.ItemCategoryWidth))
            ManufacturingTabColumnSettingsList(100) = New Setting("ItemGroupWidth", CStr(SentSettings.ItemGroupWidth))
            ManufacturingTabColumnSettingsList(101) = New Setting("ItemNameWidth", CStr(SentSettings.ItemNameWidth))
            ManufacturingTabColumnSettingsList(102) = New Setting("OwnedWidth", CStr(SentSettings.OwnedWidth))
            ManufacturingTabColumnSettingsList(103) = New Setting("TechWidth", CStr(SentSettings.TechWidth))
            ManufacturingTabColumnSettingsList(104) = New Setting("BPMEWidth", CStr(SentSettings.BPMEWidth))
            ManufacturingTabColumnSettingsList(105) = New Setting("BPTEWidth", CStr(SentSettings.BPTEWidth))
            ManufacturingTabColumnSettingsList(106) = New Setting("InputsWidth", CStr(SentSettings.InputsWidth))
            ManufacturingTabColumnSettingsList(107) = New Setting("ComparedWidth", CStr(SentSettings.ComparedWidth))
            ManufacturingTabColumnSettingsList(108) = New Setting("TotalRunsWidth", CStr(SentSettings.TotalRunsWidth))
            ManufacturingTabColumnSettingsList(109) = New Setting("SingleInventedBPCRunsWidth", CStr(SentSettings.SingleInventedBPCRunsWidth))
            ManufacturingTabColumnSettingsList(110) = New Setting("ProductionLinesWidth", CStr(SentSettings.ProductionLinesWidth))
            ManufacturingTabColumnSettingsList(111) = New Setting("LaboratoryLinesWidth", CStr(SentSettings.LaboratoryLinesWidth))
            ManufacturingTabColumnSettingsList(112) = New Setting("TotalInventionCostWidth", CStr(SentSettings.TotalInventionCostWidth))
            ManufacturingTabColumnSettingsList(113) = New Setting("TotalCopyCostWidth", CStr(SentSettings.TotalCopyCostWidth))
            ManufacturingTabColumnSettingsList(114) = New Setting("TaxesWidth", CStr(SentSettings.TaxesWidth))
            ManufacturingTabColumnSettingsList(115) = New Setting("BrokerFeesWidth", CStr(SentSettings.BrokerFeesWidth))
            ManufacturingTabColumnSettingsList(116) = New Setting("BPProductionTimeWidth", CStr(SentSettings.BPProductionTimeWidth))
            ManufacturingTabColumnSettingsList(117) = New Setting("TotalProductionTimeWidth", CStr(SentSettings.TotalProductionTimeWidth))
            ManufacturingTabColumnSettingsList(118) = New Setting("CopyTimeWidth", CStr(SentSettings.CopyTimeWidth))
            ManufacturingTabColumnSettingsList(119) = New Setting("InventionTimeWidth", CStr(SentSettings.InventionTimeWidth))
            ManufacturingTabColumnSettingsList(120) = New Setting("ItemMarketPriceWidth", CStr(SentSettings.ItemMarketPriceWidth))
            ManufacturingTabColumnSettingsList(121) = New Setting("ProfitWidth", CStr(SentSettings.ProfitWidth))
            ManufacturingTabColumnSettingsList(122) = New Setting("ProfitPercentageWidth", CStr(SentSettings.ProfitPercentageWidth))
            ManufacturingTabColumnSettingsList(123) = New Setting("IskperHourWidth", CStr(SentSettings.IskperHourWidth))
            ManufacturingTabColumnSettingsList(124) = New Setting("SVRWidth", CStr(SentSettings.SVRWidth))
            ManufacturingTabColumnSettingsList(125) = New Setting("SVRxIPHWidth", CStr(SentSettings.SVRxIPHWidth))
            ManufacturingTabColumnSettingsList(126) = New Setting("PriceTrendWidth", CStr(SentSettings.PriceTrendWidth))
            ManufacturingTabColumnSettingsList(127) = New Setting("TotalItemsSoldWidth", CStr(SentSettings.TotalItemsSoldWidth))
            ManufacturingTabColumnSettingsList(128) = New Setting("TotalOrdersFilledWidth", CStr(SentSettings.TotalOrdersFilledWidth))
            ManufacturingTabColumnSettingsList(129) = New Setting("AvgItemsperOrderWidth", CStr(SentSettings.AvgItemsperOrderWidth))
            ManufacturingTabColumnSettingsList(130) = New Setting("CurrentSellOrdersWidth", CStr(SentSettings.CurrentSellOrdersWidth))
            ManufacturingTabColumnSettingsList(131) = New Setting("CurrentBuyOrdersWidth", CStr(SentSettings.CurrentBuyOrdersWidth))
            ManufacturingTabColumnSettingsList(132) = New Setting("ItemsinProductionWidth", CStr(SentSettings.ItemsinProductionWidth))
            ManufacturingTabColumnSettingsList(133) = New Setting("ItemsinStockWidth", CStr(SentSettings.ItemsinStockWidth))
            ManufacturingTabColumnSettingsList(134) = New Setting("TotalCostWidth", CStr(SentSettings.TotalCostWidth))
            ManufacturingTabColumnSettingsList(135) = New Setting("BaseJobCostWidth", CStr(SentSettings.BaseJobCostWidth))
            ManufacturingTabColumnSettingsList(136) = New Setting("NumBPsWidth", CStr(SentSettings.NumBPsWidth))
            ManufacturingTabColumnSettingsList(137) = New Setting("InventionChanceWidth", CStr(SentSettings.InventionChanceWidth))
            ManufacturingTabColumnSettingsList(138) = New Setting("BPTypeWidth", CStr(SentSettings.BPTypeWidth))
            ManufacturingTabColumnSettingsList(139) = New Setting("RaceWidth", CStr(SentSettings.RaceWidth))
            ManufacturingTabColumnSettingsList(140) = New Setting("VolumeperItemWidth", CStr(SentSettings.VolumeperItemWidth))
            ManufacturingTabColumnSettingsList(141) = New Setting("TotalVolumeWidth", CStr(SentSettings.TotalVolumeWidth))
            ManufacturingTabColumnSettingsList(142) = New Setting("PortionSizeWidth", CStr(SentSettings.PortionSizeWidth))
            ManufacturingTabColumnSettingsList(143) = New Setting("ManufacturingJobFeeWidth", CStr(SentSettings.ManufacturingJobFeeWidth))
            ManufacturingTabColumnSettingsList(144) = New Setting("ManufacturingFacilityNameWidth", CStr(SentSettings.ManufacturingFacilityNameWidth))
            ManufacturingTabColumnSettingsList(145) = New Setting("ManufacturingFacilitySystemWidth", CStr(SentSettings.ManufacturingFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(146) = New Setting("ManufacturingFacilityRegionWidth", CStr(SentSettings.ManufacturingFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(147) = New Setting("ManufacturingFacilitySystemIndexWidth", CStr(SentSettings.ManufacturingFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(148) = New Setting("ManufacturingFacilityTaxWidth", CStr(SentSettings.ManufacturingFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(149) = New Setting("ManufacturingFacilityMEBonusWidth", CStr(SentSettings.ManufacturingFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(150) = New Setting("ManufacturingFacilityTEBonusWidth", CStr(SentSettings.ManufacturingFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(151) = New Setting("ManufacturingFacilityUsageWidth", CStr(SentSettings.ManufacturingFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(152) = New Setting("ManufacturingFacilityFWSystemLevelWidth", CStr(SentSettings.ManufacturingFacilityFWSystemLevelWidth))
            ManufacturingTabColumnSettingsList(153) = New Setting("ComponentFacilityNameWidth", CStr(SentSettings.ComponentFacilityNameWidth))
            ManufacturingTabColumnSettingsList(154) = New Setting("ComponentFacilitySystemWidth", CStr(SentSettings.ComponentFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(155) = New Setting("ComponentFacilityRegionWidth", CStr(SentSettings.ComponentFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(156) = New Setting("ComponentFacilitySystemIndexWidth", CStr(SentSettings.ComponentFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(157) = New Setting("ComponentFacilityTaxWidth", CStr(SentSettings.ComponentFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(158) = New Setting("ComponentFacilityMEBonusWidth", CStr(SentSettings.ComponentFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(159) = New Setting("ComponentFacilityTEBonusWidth", CStr(SentSettings.ComponentFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(160) = New Setting("ComponentFacilityUsageWidth", CStr(SentSettings.ComponentFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(161) = New Setting("ComponentFacilityFWSystemLevelWidth", CStr(SentSettings.ComponentFacilityFWSystemLevelWidth))
            ManufacturingTabColumnSettingsList(162) = New Setting("CapComponentFacilityNameWidth", CStr(SentSettings.CapComponentFacilityNameWidth))
            ManufacturingTabColumnSettingsList(163) = New Setting("CapComponentFacilitySystemWidth", CStr(SentSettings.CapComponentFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(164) = New Setting("CapComponentFacilityRegionWidth", CStr(SentSettings.CapComponentFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(165) = New Setting("CapComponentFacilitySystemIndexWidth", CStr(SentSettings.CapComponentFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(166) = New Setting("CapComponentFacilityTaxWidth", CStr(SentSettings.CapComponentFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(167) = New Setting("CapComponentFacilityMEBonusWidth", CStr(SentSettings.CapComponentFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(168) = New Setting("CapComponentFacilityTEBonusWidth", CStr(SentSettings.CapComponentFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(169) = New Setting("CapComponentFacilityUsageWidth", CStr(SentSettings.CapComponentFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(170) = New Setting("CapComponentFacilityFWSystemLevelWidth", CStr(SentSettings.CapComponentFacilityFWSystemLevelWidth))
            ManufacturingTabColumnSettingsList(171) = New Setting("CopyingFacilityNameWidth", CStr(SentSettings.CopyingFacilityNameWidth))
            ManufacturingTabColumnSettingsList(172) = New Setting("CopyingFacilitySystemWidth", CStr(SentSettings.CopyingFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(173) = New Setting("CopyingFacilityRegionWidth", CStr(SentSettings.CopyingFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(174) = New Setting("CopyingFacilitySystemIndexWidth", CStr(SentSettings.CopyingFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(175) = New Setting("CopyingFacilityTaxWidth", CStr(SentSettings.CopyingFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(176) = New Setting("CopyingFacilityMEBonusWidth", CStr(SentSettings.CopyingFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(177) = New Setting("CopyingFacilityTEBonusWidth", CStr(SentSettings.CopyingFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(178) = New Setting("CopyingFacilityUsageWidth", CStr(SentSettings.CopyingFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(179) = New Setting("CopyingFacilityFWSystemLevelWidth", CStr(SentSettings.CopyingFacilityFWSystemLevelWidth))
            ManufacturingTabColumnSettingsList(180) = New Setting("InventionFacilityNameWidth", CStr(SentSettings.InventionFacilityNameWidth))
            ManufacturingTabColumnSettingsList(181) = New Setting("InventionFacilitySystemWidth", CStr(SentSettings.InventionFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(182) = New Setting("InventionFacilityRegionWidth", CStr(SentSettings.InventionFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(183) = New Setting("InventionFacilitySystemIndexWidth", CStr(SentSettings.InventionFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(184) = New Setting("InventionFacilityTaxWidth", CStr(SentSettings.InventionFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(185) = New Setting("InventionFacilityMEBonusWidth", CStr(SentSettings.InventionFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(186) = New Setting("InventionFacilityTEBonusWidth", CStr(SentSettings.InventionFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(187) = New Setting("InventionFacilityUsageWidth", CStr(SentSettings.InventionFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(188) = New Setting("InventionFacilityFWSystemLevelWidth", CStr(SentSettings.InventionFacilityFWSystemLevelWidth))
            ManufacturingTabColumnSettingsList(189) = New Setting("ReactionFacilityNameWidth", CStr(SentSettings.ReactionFacilityNameWidth))
            ManufacturingTabColumnSettingsList(190) = New Setting("ReactionFacilitySystemWidth", CStr(SentSettings.ReactionFacilitySystemWidth))
            ManufacturingTabColumnSettingsList(191) = New Setting("ReactionFacilityRegionWidth", CStr(SentSettings.ReactionFacilityRegionWidth))
            ManufacturingTabColumnSettingsList(192) = New Setting("ReactionFacilitySystemIndexWidth", CStr(SentSettings.ReactionFacilitySystemIndexWidth))
            ManufacturingTabColumnSettingsList(193) = New Setting("ReactionFacilityTaxWidth", CStr(SentSettings.ReactionFacilityTaxWidth))
            ManufacturingTabColumnSettingsList(194) = New Setting("ReactionFacilityMEBonusWidth", CStr(SentSettings.ReactionFacilityMEBonusWidth))
            ManufacturingTabColumnSettingsList(195) = New Setting("ReactionFacilityTEBonusWidth", CStr(SentSettings.ReactionFacilityTEBonusWidth))
            ManufacturingTabColumnSettingsList(196) = New Setting("ReactionFacilityUsageWidth", CStr(SentSettings.ReactionFacilityUsageWidth))
            ManufacturingTabColumnSettingsList(197) = New Setting("ReactionFacilityFWSystemLevelWidth", CStr(SentSettings.ReactionFacilityFWSystemLevelWidth))

            ManufacturingTabColumnSettingsList(198) = New Setting("OrderMTByColumn", CStr(SentSettings.OrderByColumn))
            ManufacturingTabColumnSettingsList(199) = New Setting("OrderMTType", CStr(SentSettings.OrderType))


            ManufacturingTabColumnSettingsList(200) = New Setting("Volatility", CStr(SentSettings.Volatility))
            ManufacturingTabColumnSettingsList(201) = New Setting("VolatilityWidth", CStr(SentSettings.VolatilityWidth))
            ManufacturingTabColumnSettingsList(202) = New Setting("Score", CStr(SentSettings.Score))
            ManufacturingTabColumnSettingsList(203) = New Setting("ScoreWidth", CStr(SentSettings.ScoreWidth))
            ManufacturingTabColumnSettingsList(204) = New Setting("RiskPrice", CStr(SentSettings.RiskPrice))
            ManufacturingTabColumnSettingsList(205) = New Setting("RiskPriceWidth", CStr(SentSettings.RiskPriceWidth))
            ManufacturingTabColumnSettingsList(206) = New Setting("RiskProfit", CStr(SentSettings.RiskPrice))
            ManufacturingTabColumnSettingsList(207) = New Setting("RiskProfitWidth", CStr(SentSettings.RiskPriceWidth))
            ManufacturingTabColumnSettingsList(208) = New Setting("RiskIPH", CStr(SentSettings.RiskPrice))
            ManufacturingTabColumnSettingsList(209) = New Setting("RiskIPHWidth", CStr(SentSettings.RiskPriceWidth))

            Call WriteSettingsToFile(SettingsFolder, ManufacturingTabColumnSettingsFileName, ManufacturingTabColumnSettingsList, ManufacturingTabColumnSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Industry Jobs Column Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetManufacturingTabColumnSettings() As ManufacturingTabColumnSettings
        Return ManufacturingTabColumnSettings
    End Function

#End Region

#Region "Industry Belt Flip"

    ' Loads the tab settings
    Public Function LoadIndustryFlipBeltColumnSettings() As IndustryFlipBeltSettings
        Dim TempSettings As IndustryFlipBeltSettings = Nothing

        Try
            If FileExists(SettingsFolder, IndustryFlipBeltSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .CycleTime = CDbl(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "CycleTime", DefaultCycleTime))
                    .m3perCycle = CDbl(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "m3perCycle", Defaultm3perCycle))
                    .NumMiners = CInt(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeInteger, IndustryFlipBeltSettingsFileName, "NumMiners", DefaultNumMiners))
                    .CompressOre = CBool(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "CompressOre", DefaultCompressOre))
                    .IPHperMiner = CBool(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "IPHperMiner", DefaultIPHperMiner))
                    .IncludeBrokerFees = CInt(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeInteger, IndustryFlipBeltSettingsFileName, "IncludeBrokerFees", DefaultIncludeBrokerFees))
                    .IncludeTaxes = CBool(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "IncludeTaxes", DefaultIncludeTaxes))
                    .TrueSec = CStr(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeString, IndustryFlipBeltSettingsFileName, "TrueSec", DefaultTruesec))
                    .BrokerFeeRate = CDbl(GetSettingValue(SettingsFolder, BPSettingsFileName, SettingTypes.TypeDouble, BPSettingsFileName, "BrokerFeeRate", DefaultBPBrokerFeeRate))

                    .RefiningEfficiency = CDbl(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "RefiningEfficiency", DefaultRefiningEfficency))
                    .RefiningTax = CDbl(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "RefiningTax", DefaultRefineTax))
                    .RefineCorpStanding = CDbl(GetSettingValue(SettingsFolder, IndustryFlipBeltSettingsFileName, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "RefineCorpStanding", DefaultRefineCorpStanding))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultIndustryFlipBeltSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Industry Flip Belt Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultIndustryFlipBeltSettings()
        End Try

        ' Save them locally and then export
        IndustryFlipBeltsSettings = TempSettings

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultIndustryFlipBeltSettings() As IndustryFlipBeltSettings
        Dim LocalSettings As IndustryFlipBeltSettings

        With LocalSettings
            .CycleTime = DefaultCycleTime
            .m3perCycle = Defaultm3perCycle
            .NumMiners = DefaultNumMiners
            .CompressOre = DefaultCompressOre
            .IPHperMiner = DefaultIPHperMiner
            .IncludeBrokerFees = DefaultIncludeBrokerFees
            .BrokerFeeRate = DefaultBFBrokerFeeRate
            .IncludeTaxes = DefaultIncludeTaxes
            .TrueSec = DefaultTruesec
            .RefiningEfficiency = DefaultRefiningEfficency
            .RefineCorpStanding = DefaultRefineCorpStanding
            .RefiningTax = DefaultRefineTax
        End With

        ' Save locally
        IndustryFlipBeltsSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveIndustryFlipBeltSettings(SentSettings As IndustryFlipBeltSettings)
        Dim IndustryFlipBeltSettingsList(11) As Setting

        Try
            IndustryFlipBeltSettingsList(0) = New Setting("CycleTime", CStr(SentSettings.CycleTime))
            IndustryFlipBeltSettingsList(1) = New Setting("m3perCycle", CStr(SentSettings.m3perCycle))
            IndustryFlipBeltSettingsList(2) = New Setting("NumMiners", CStr(SentSettings.NumMiners))
            IndustryFlipBeltSettingsList(3) = New Setting("CompressedOre", CStr(SentSettings.CompressOre))
            IndustryFlipBeltSettingsList(4) = New Setting("IPHperMiner", CStr(SentSettings.IPHperMiner))
            IndustryFlipBeltSettingsList(5) = New Setting("IncludeBrokerFees", CStr(SentSettings.IncludeBrokerFees))
            IndustryFlipBeltSettingsList(6) = New Setting("IncludeTaxes", CStr(SentSettings.IncludeTaxes))
            IndustryFlipBeltSettingsList(7) = New Setting("TrueSec", CStr(SentSettings.TrueSec))
            IndustryFlipBeltSettingsList(8) = New Setting("RefiningEfficiency", CStr(SentSettings.RefiningEfficiency))
            IndustryFlipBeltSettingsList(9) = New Setting("RefineCorpStanding", CStr(SentSettings.RefineCorpStanding))
            IndustryFlipBeltSettingsList(10) = New Setting("RefiningTax", CStr(SentSettings.RefiningTax))
            IndustryFlipBeltSettingsList(11) = New Setting("BrokerFeeRate", CStr(SentSettings.BrokerFeeRate))

            Call WriteSettingsToFile(SettingsFolder, IndustryFlipBeltSettingsFileName, IndustryFlipBeltSettingsList, IndustryFlipBeltSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Industry Flip Belt Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetIndustryFlipBeltSettings() As IndustryFlipBeltSettings
        Return IndustryFlipBeltsSettings
    End Function

#End Region

#Region "Industry Belt Ore Checks"

    ' Loads the tab settings
    Public Function LoadIndustryBeltOreChecksSettings(Belt As BeltType) As IndustryBeltOreChecks
        Dim TempSettings As IndustryBeltOreChecks = Nothing

        Select Case Belt
            Case BeltType.Small
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName1
            Case BeltType.Medium
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName2
            Case BeltType.Large
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName3
            Case BeltType.Enormous
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName4
            Case BeltType.Colossal
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName5
        End Select

        Try
            If FileExists(SettingsFolder, IndustryBeltOreChecksFileName) Then
                'Get the settings
                With TempSettings
                    .Plagioclase = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Plagioclase", DefaultPlagioclase))
                    .Spodumain = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Spodumain", DefaultSpodumain))
                    .Kernite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Kernite", DefaultKernite))
                    .Hedbergite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Hedbergite", DefaultHedbergite))
                    .Arkonor = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Arkonor", DefaultArkonor))
                    .Bistot = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Bistot", DefaultBistot))
                    .Pyroxeres = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Pyroxeres", DefaultPyroxeres))
                    .Crokite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Crokite", DefaultCrokite))
                    .Jaspet = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Jaspet", DefaultJaspet))
                    .Omber = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Omber", DefaultOmber))
                    .Scordite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Scordite", DefaultScordite))
                    .Gneiss = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Gneiss", DefaultGneiss))
                    .Veldspar = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Veldspar", DefaultVeldspar))
                    .Hemorphite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Hemorphite", DefaultHemorphite))
                    .DarkOchre = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "DarkOchre", DefaultDarkOchre))
                    .Mercoxit = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Mercoxit", DefaultMercoxit))
                    .CrimsonArkonor = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CrimsonArkonor", DefaultCrimsonArkonor))
                    .PrimeArkonor = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PrimeArkonor", DefaultPrimeArkonor))
                    .TriclinicBistot = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "TriclinicBistot", DefaultTriclinicBistot))
                    .MonoclinicBistot = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MonoclinicBistot", DefaultMonoclinicBistot))
                    .SharpCrokite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SharpCrokite", DefaultSharpCrokite))
                    .CrystallineCrokite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CrystallineCrokite", DefaultCrystallineCrokite))
                    .OnyxOchre = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "OnyxOchre", DefaultOnyxOchre))
                    .ObsidianOchre = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ObsidianOchre", DefaultObsidianOchre))
                    .VitricHedbergite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VitricHedbergite", DefaultVitricHedbergite))
                    .GlazedHedbergite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GlazedHedbergite", DefaultGlazedHedbergite))
                    .VividHemorphite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VividHemorphite", DefaultVividHemorphite))
                    .RadiantHemorphite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "RadiantHemorphite", DefaultRadiantHemorphite))
                    .PureJaspet = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PureJaspet", DefaultPureJaspet))
                    .PristineJaspet = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PristineJaspet", DefaultPristineJaspet))
                    .LuminousKernite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "LuminousKernite", DefaultLuminousKernite))
                    .FieryKernite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "FieryKernite", DefaultFieryKernite))
                    .AzurePlagioclase = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "AzurePlagioclase", DefaultAzurePlagioclase))
                    .RichPlagioclase = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "RichPlagioclase", DefaultRichPlagioclase))
                    .SolidPyroxeres = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SolidPyroxeres", DefaultSolidPyroxeres))
                    .ViscousPyroxeres = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ViscousPyroxeres", DefaultViscousPyroxeres))
                    .CondensedScordite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CondensedScordite", DefaultCondensedScordite))
                    .MassiveScordite = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MassiveScordite", DefaultMassiveScordite))
                    .BrightSpodumain = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "BrightSpodumain", DefaultBrightSpodumain))
                    .GleamingSpodumain = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GleamingSpodumain", DefaultGleamingSpodumain))
                    .ConcentratedVeldspar = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ConcentratedVeldspar", DefaultConcentratedVeldspar))
                    .DenseVeldspar = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "DenseVeldspar", DefaultDenseVeldspar))
                    .IridescentGneiss = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "IridescentGneiss", DefaultIridescentGneiss))
                    .PrismaticGneiss = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PrismaticGneiss", DefaultPrismaticGneiss))
                    .SilveryOmber = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SilveryOmber", DefaultSilveryOmber))
                    .GoldenOmber = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GoldenOmber", DefaultGoldenOmber))
                    .MagmaMercoxit = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MagmaMercoxit", DefaultMagmaMercoxit))
                    .VitreousMercoxit = CBool(GetSettingValue(SettingsFolder, IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VitreousMercoxit", DefaultVitreousMercoxit))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultIndustryBeltOreChecksSettings(Belt)
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Industry Flip Belt Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultIndustryBeltOreChecksSettings(Belt)
        End Try

        ' Save them locally and then export
        Select Case Belt
            Case BeltType.Small
                IndustryBeltOreChecksSettings1 = TempSettings
            Case BeltType.Medium
                IndustryBeltOreChecksSettings2 = TempSettings
            Case BeltType.Large
                IndustryBeltOreChecksSettings3 = TempSettings
            Case BeltType.Enormous
                IndustryBeltOreChecksSettings4 = TempSettings
            Case BeltType.Colossal
                IndustryBeltOreChecksSettings5 = TempSettings
        End Select

        Return TempSettings

    End Function

    ' Loads the Defaults for the tab
    Public Function SetDefaultIndustryBeltOreChecksSettings(Belt As BeltType) As IndustryBeltOreChecks
        Dim LocalSettings As IndustryBeltOreChecks

        With LocalSettings
            .Plagioclase = DefaultPlagioclase
            .Spodumain = DefaultSpodumain
            .Kernite = DefaultKernite
            .Hedbergite = DefaultHedbergite
            .Arkonor = DefaultArkonor
            .Bistot = DefaultBistot
            .Pyroxeres = DefaultPyroxeres
            .Crokite = DefaultCrokite
            .Jaspet = DefaultJaspet
            .Omber = DefaultOmber
            .Scordite = DefaultScordite
            .Gneiss = DefaultGneiss
            .Veldspar = DefaultVeldspar
            .Hemorphite = DefaultHemorphite
            .DarkOchre = DefaultDarkOchre
            .Mercoxit = DefaultMercoxit
            .CrimsonArkonor = DefaultCrimsonArkonor
            .PrimeArkonor = DefaultPrimeArkonor
            .TriclinicBistot = DefaultTriclinicBistot
            .MonoclinicBistot = DefaultMonoclinicBistot
            .SharpCrokite = DefaultSharpCrokite
            .CrystallineCrokite = DefaultCrystallineCrokite
            .OnyxOchre = DefaultOnyxOchre
            .ObsidianOchre = DefaultObsidianOchre
            .VitricHedbergite = DefaultVitricHedbergite
            .GlazedHedbergite = DefaultGlazedHedbergite
            .VividHemorphite = DefaultVividHemorphite
            .RadiantHemorphite = DefaultRadiantHemorphite
            .PureJaspet = DefaultPureJaspet
            .PristineJaspet = DefaultPristineJaspet
            .LuminousKernite = DefaultLuminousKernite
            .FieryKernite = DefaultFieryKernite
            .AzurePlagioclase = DefaultAzurePlagioclase
            .RichPlagioclase = DefaultRichPlagioclase
            .SolidPyroxeres = DefaultSolidPyroxeres
            .ViscousPyroxeres = DefaultViscousPyroxeres
            .CondensedScordite = DefaultCondensedScordite
            .MassiveScordite = DefaultMassiveScordite
            .BrightSpodumain = DefaultBrightSpodumain
            .GleamingSpodumain = DefaultGleamingSpodumain
            .ConcentratedVeldspar = DefaultConcentratedVeldspar
            .DenseVeldspar = DefaultDenseVeldspar
            .IridescentGneiss = DefaultIridescentGneiss
            .PrismaticGneiss = DefaultPrismaticGneiss
            .SilveryOmber = DefaultSilveryOmber
            .GoldenOmber = DefaultGoldenOmber
            .MagmaMercoxit = DefaultMagmaMercoxit
            .VitreousMercoxit = DefaultVitreousMercoxit
        End With

        ' Save locally
        ' Save them locally and then export
        Select Case Belt
            Case BeltType.Small
                IndustryBeltOreChecksSettings1 = LocalSettings
            Case BeltType.Medium
                IndustryBeltOreChecksSettings2 = LocalSettings
            Case BeltType.Large
                IndustryBeltOreChecksSettings3 = LocalSettings
            Case BeltType.Enormous
                IndustryBeltOreChecksSettings4 = LocalSettings
            Case BeltType.Colossal
                IndustryBeltOreChecksSettings5 = LocalSettings
        End Select

        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveIndustryBeltOreChecksSettings(SentSettings As IndustryBeltOreChecks, Belt As BeltType)
        Dim IndustryBeltOreChecksList(47) As Setting

        Select Case Belt
            Case BeltType.Small
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName1
            Case BeltType.Medium
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName2
            Case BeltType.Large
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName3
            Case BeltType.Enormous
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName4
            Case BeltType.Colossal
                IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName & IndustryBeltOreChecksFileName5
        End Select

        Try
            IndustryBeltOreChecksList(0) = New Setting("Plagioclase", CStr(SentSettings.Plagioclase))
            IndustryBeltOreChecksList(1) = New Setting("Spodumain", CStr(SentSettings.Spodumain))
            IndustryBeltOreChecksList(2) = New Setting("Kernite", CStr(SentSettings.Kernite))
            IndustryBeltOreChecksList(3) = New Setting("Hedbergite", CStr(SentSettings.Hedbergite))
            IndustryBeltOreChecksList(4) = New Setting("Arkonor", CStr(SentSettings.Arkonor))
            IndustryBeltOreChecksList(5) = New Setting("Bistot", CStr(SentSettings.Bistot))
            IndustryBeltOreChecksList(6) = New Setting("Pyroxeres", CStr(SentSettings.Pyroxeres))
            IndustryBeltOreChecksList(7) = New Setting("Crokite", CStr(SentSettings.Crokite))
            IndustryBeltOreChecksList(8) = New Setting("Jaspet", CStr(SentSettings.Jaspet))
            IndustryBeltOreChecksList(9) = New Setting("Omber", CStr(SentSettings.Omber))
            IndustryBeltOreChecksList(10) = New Setting("Scordite", CStr(SentSettings.Scordite))
            IndustryBeltOreChecksList(11) = New Setting("Gneiss", CStr(SentSettings.Gneiss))
            IndustryBeltOreChecksList(12) = New Setting("Veldspar", CStr(SentSettings.Veldspar))
            IndustryBeltOreChecksList(13) = New Setting("Hemorphite", CStr(SentSettings.Hemorphite))
            IndustryBeltOreChecksList(14) = New Setting("DarkOchre", CStr(SentSettings.DarkOchre))
            IndustryBeltOreChecksList(15) = New Setting("Mercoxit", CStr(SentSettings.Mercoxit))
            IndustryBeltOreChecksList(16) = New Setting("CrimsonArkonor", CStr(SentSettings.CrimsonArkonor))
            IndustryBeltOreChecksList(17) = New Setting("PrimeArkonor", CStr(SentSettings.PrimeArkonor))
            IndustryBeltOreChecksList(18) = New Setting("TriclinicBistot", CStr(SentSettings.TriclinicBistot))
            IndustryBeltOreChecksList(19) = New Setting("MonoclinicBistot", CStr(SentSettings.MonoclinicBistot))
            IndustryBeltOreChecksList(20) = New Setting("SharpCrokite", CStr(SentSettings.SharpCrokite))
            IndustryBeltOreChecksList(21) = New Setting("CrystallineCrokite", CStr(SentSettings.CrystallineCrokite))
            IndustryBeltOreChecksList(22) = New Setting("OnyxOchre", CStr(SentSettings.OnyxOchre))
            IndustryBeltOreChecksList(23) = New Setting("ObsidianOchre", CStr(SentSettings.ObsidianOchre))
            IndustryBeltOreChecksList(24) = New Setting("VitricHedbergite", CStr(SentSettings.VitricHedbergite))
            IndustryBeltOreChecksList(25) = New Setting("GlazedHedbergite", CStr(SentSettings.GlazedHedbergite))
            IndustryBeltOreChecksList(26) = New Setting("VividHemorphite", CStr(SentSettings.VividHemorphite))
            IndustryBeltOreChecksList(27) = New Setting("RadiantHemorphite", CStr(SentSettings.RadiantHemorphite))
            IndustryBeltOreChecksList(28) = New Setting("PureJaspet", CStr(SentSettings.PureJaspet))
            IndustryBeltOreChecksList(29) = New Setting("PristineJaspet", CStr(SentSettings.PristineJaspet))
            IndustryBeltOreChecksList(30) = New Setting("LuminousKernite", CStr(SentSettings.LuminousKernite))
            IndustryBeltOreChecksList(31) = New Setting("FieryKernite", CStr(SentSettings.FieryKernite))
            IndustryBeltOreChecksList(32) = New Setting("AzurePlagioclase", CStr(SentSettings.AzurePlagioclase))
            IndustryBeltOreChecksList(33) = New Setting("RichPlagioclase", CStr(SentSettings.RichPlagioclase))
            IndustryBeltOreChecksList(34) = New Setting("SolidPyroxeres", CStr(SentSettings.SolidPyroxeres))
            IndustryBeltOreChecksList(35) = New Setting("ViscousPyroxeres", CStr(SentSettings.ViscousPyroxeres))
            IndustryBeltOreChecksList(36) = New Setting("CondensedScordite", CStr(SentSettings.CondensedScordite))
            IndustryBeltOreChecksList(37) = New Setting("MassiveScordite", CStr(SentSettings.MassiveScordite))
            IndustryBeltOreChecksList(38) = New Setting("BrightSpodumain", CStr(SentSettings.BrightSpodumain))
            IndustryBeltOreChecksList(39) = New Setting("GleamingSpodumain", CStr(SentSettings.GleamingSpodumain))
            IndustryBeltOreChecksList(40) = New Setting("ConcentratedVeldspar", CStr(SentSettings.ConcentratedVeldspar))
            IndustryBeltOreChecksList(41) = New Setting("DenseVeldspar", CStr(SentSettings.DenseVeldspar))
            IndustryBeltOreChecksList(42) = New Setting("IridescentGneiss", CStr(SentSettings.IridescentGneiss))
            IndustryBeltOreChecksList(43) = New Setting("PrismaticGneiss", CStr(SentSettings.PrismaticGneiss))
            IndustryBeltOreChecksList(44) = New Setting("SilveryOmber", CStr(SentSettings.SilveryOmber))
            IndustryBeltOreChecksList(45) = New Setting("GoldenOmber", CStr(SentSettings.GoldenOmber))
            IndustryBeltOreChecksList(46) = New Setting("MagmaMercoxit", CStr(SentSettings.MagmaMercoxit))
            IndustryBeltOreChecksList(47) = New Setting("VitreousMercoxit", CStr(SentSettings.VitreousMercoxit))

            Call WriteSettingsToFile(SettingsFolder, IndustryBeltOreChecksFileName, IndustryBeltOreChecksList, IndustryBeltOreChecksFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Industry Flip Belt Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetIndustryBeltOreChecksSettings(Belt As BeltType) As IndustryBeltOreChecks
        Select Case Belt
            Case BeltType.Small
                Return IndustryBeltOreChecksSettings1
            Case BeltType.Medium
                Return IndustryBeltOreChecksSettings2
            Case BeltType.Large
                Return IndustryBeltOreChecksSettings3
            Case BeltType.Enormous
                Return IndustryBeltOreChecksSettings4
            Case BeltType.Colossal
                Return IndustryBeltOreChecksSettings5
        End Select
    End Function

#End Region

#Region "Asset Window Settings"

    ' Loads the tab settings
    Public Function LoadAssetWindowSettings(Location As AssetWindow) As AssetWindowSettings
        Dim TempSettings As AssetWindowSettings = Nothing
        Dim AssetWindowFileName As String = ""

        Select Case Location
            Case AssetWindow.DefaultView
                AssetWindowFileName = AssetWindowFileNameDefault
            Case AssetWindow.ManufacturingTab
                AssetWindowFileName = AssetWindowFileNameManufacturingTab
            Case AssetWindow.ShoppingList
                AssetWindowFileName = AssetWindowFileNameShoppingList
        End Select

        Try
            If FileExists(SettingsFolder, AssetWindowFileName) Then

                'Get the settings
                With TempSettings
                    ' Main window
                    .AssetType = CStr(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeString, AssetWindowFileName, "AssetType", DefaultAssetType))
                    .SortbyName = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "SortbyName", DefaultAssetSortbyName))

                    ' Search Settings
                    .ItemFilterText = CStr(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeString, AssetWindowFileName, "ItemFilterText", DefaultAssetItemTextFilter))
                    .AllItems = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllItems", DefaultAllItems))
                    .AllRawMats = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllRawMats", DefaultAssetItemChecks))
                    .Minerals = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Minerals", DefaultAssetItemChecks))
                    .IceProducts = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "IceProducts", DefaultAssetItemChecks))
                    .Gas = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Gas", DefaultAssetItemChecks))
                    .Misc = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Misc", DefaultAssetItemChecks))
                    .BPCs = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "BPCs", False))
                    .AncientRelics = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AncientRelics", DefaultAssetItemChecks))
                    .AncientSalvage = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AncientSalvage", DefaultAssetItemChecks))
                    .Salvage = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Salvage", DefaultAssetItemChecks))
                    .StructureRigs = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "StructureRigs", DefaultAssetItemChecks))
                    .StructureModules = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "StructureModules", DefaultAssetItemChecks))
                    .Planetary = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Planetary", DefaultAssetItemChecks))
                    .Datacores = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Datacores", DefaultAssetItemChecks))
                    .Decryptors = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Decryptors", DefaultAssetItemChecks))
                    .RawMats = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "RawMats", DefaultAssetItemChecks))
                    .ProcessedMats = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "ProcessedMats", DefaultAssetItemChecks))
                    .AdvancedMats = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AdvancedMats", DefaultAssetItemChecks))
                    .MatsandCompounds = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "MatsandCompounds", DefaultAssetItemChecks))
                    .DroneComponents = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "DroneComponents", DefaultAssetItemChecks))
                    .BoosterMats = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "BoosterMats", DefaultAssetItemChecks))
                    .Polymers = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Polymers", DefaultAssetItemChecks))
                    .Asteroids = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Asteroids", DefaultAssetItemChecks))
                    .AllManufacturedItems = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllManufacturedItems", DefaultAssetItemChecks))
                    .Ships = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Ships", DefaultAssetItemChecks))
                    .Modules = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Modules", DefaultAssetItemChecks))
                    .Drones = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Drones", DefaultAssetItemChecks))
                    .Boosters = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Boosters", DefaultAssetItemChecks))
                    .Rigs = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Rigs", DefaultAssetItemChecks))
                    .Charges = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Charges", DefaultAssetItemChecks))
                    .Subsystems = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Subsystems", DefaultAssetItemChecks))
                    .Structures = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Structures", DefaultAssetItemChecks))
                    .Tools = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Tools", DefaultAssetItemChecks))
                    .DataInterfaces = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "DataInterfaces", DefaultAssetItemChecks))
                    .CapT2Components = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "CapT2Components", DefaultAssetItemChecks))
                    .CapitalComponents = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "CapitalComponents", DefaultAssetItemChecks))
                    .Components = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Components", DefaultAssetItemChecks))
                    .Hybrid = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Hybrid", DefaultAssetItemChecks))
                    .StructureComponents = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Structure Components", DefaultAssetItemChecks))
                    .FuelBlocks = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "FuelBlocks", DefaultAssetItemChecks))
                    .T1 = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T1", DefaultAssetItemChecks))
                    .T2 = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T2", DefaultAssetItemChecks))
                    .T3 = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T3", DefaultAssetItemChecks))
                    .Faction = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Faction", DefaultAssetItemChecks))
                    .Pirate = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Pirate", DefaultAssetItemChecks))
                    .Storyline = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Storyline", DefaultAssetItemChecks))

                    .Celestials = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Celestials", DefaultAssetItemChecks))
                    .Deployables = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Deployables", DefaultAssetItemChecks))
                    .Implants = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Implants", DefaultAssetItemChecks))

                    .AbyssalMaterials = CBool(GetSettingValue(SettingsFolder, AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AbyssalMaterials", DefaultAssetItemChecks))

                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultAssetWindowSettings(Location)

            End If

        Catch ex As Exception
            MsgBox("An error occured when loading Asset Window Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults                            
            TempSettings = SetDefaultAssetWindowSettings(Location)
        End Try

        ' Save them locally and then export
        Select Case Location
            Case AssetWindow.ManufacturingTab
                AssetWindowSettingsManufacturingTab = TempSettings
            Case AssetWindow.ShoppingList
                AssetWindowSettingsShoppingList = TempSettings
        End Select

        Return TempSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveAssetWindowSettings(ItemsSelected As AssetWindowSettings, Location As AssetWindow)
        Dim AssetWindowSettingsList(52) As Setting
        Dim AssetWindowFileName As String = ""

        Select Case Location
            Case AssetWindow.DefaultView
                AssetWindowFileName = AssetWindowFileNameDefault
            Case AssetWindow.ManufacturingTab
                AssetWindowFileName = AssetWindowFileNameManufacturingTab
            Case AssetWindow.ShoppingList
                AssetWindowFileName = AssetWindowFileNameShoppingList
        End Select

        Try
            AssetWindowSettingsList(0) = New Setting("AllRawMats", CStr(ItemsSelected.AllRawMats))
            AssetWindowSettingsList(1) = New Setting("Minerals", CStr(ItemsSelected.Minerals))
            AssetWindowSettingsList(2) = New Setting("IceProducts", CStr(ItemsSelected.IceProducts))
            AssetWindowSettingsList(3) = New Setting("Gas", CStr(ItemsSelected.Gas))
            AssetWindowSettingsList(4) = New Setting("AncientRelics", CStr(ItemsSelected.AncientRelics))
            AssetWindowSettingsList(5) = New Setting("AncientSalvage", CStr(ItemsSelected.AncientSalvage))
            AssetWindowSettingsList(6) = New Setting("Salvage", CStr(ItemsSelected.Salvage))
            AssetWindowSettingsList(7) = New Setting("StructureRigs", CStr(ItemsSelected.StructureRigs))
            AssetWindowSettingsList(8) = New Setting("Planetary", CStr(ItemsSelected.Planetary))
            AssetWindowSettingsList(9) = New Setting("Datacores", CStr(ItemsSelected.Datacores))
            AssetWindowSettingsList(10) = New Setting("Decryptors", CStr(ItemsSelected.Decryptors))
            AssetWindowSettingsList(11) = New Setting("RawMats", CStr(ItemsSelected.RawMats))
            AssetWindowSettingsList(12) = New Setting("ProcessedMats", CStr(ItemsSelected.ProcessedMats))
            AssetWindowSettingsList(13) = New Setting("AdvancedMats", CStr(ItemsSelected.AdvancedMats))
            AssetWindowSettingsList(14) = New Setting("MatsandCompounds", CStr(ItemsSelected.MatsandCompounds))
            AssetWindowSettingsList(15) = New Setting("DroneComponents", CStr(ItemsSelected.DroneComponents))
            AssetWindowSettingsList(16) = New Setting("BoosterMats", CStr(ItemsSelected.BoosterMats))
            AssetWindowSettingsList(17) = New Setting("Polymers", CStr(ItemsSelected.Polymers))
            AssetWindowSettingsList(18) = New Setting("AllManufacturedItems", CStr(ItemsSelected.AllManufacturedItems))
            AssetWindowSettingsList(19) = New Setting("Ships", CStr(ItemsSelected.Ships))
            AssetWindowSettingsList(20) = New Setting("Modules", CStr(ItemsSelected.Modules))
            AssetWindowSettingsList(21) = New Setting("Drones", CStr(ItemsSelected.Drones))
            AssetWindowSettingsList(22) = New Setting("Boosters", CStr(ItemsSelected.Boosters))
            AssetWindowSettingsList(23) = New Setting("Rigs", CStr(ItemsSelected.Rigs))
            AssetWindowSettingsList(24) = New Setting("Charges", CStr(ItemsSelected.Charges))
            AssetWindowSettingsList(25) = New Setting("Subsystems", CStr(ItemsSelected.Subsystems))
            AssetWindowSettingsList(26) = New Setting("Structures", CStr(ItemsSelected.Structures))
            AssetWindowSettingsList(27) = New Setting("Tools", CStr(ItemsSelected.Tools))
            AssetWindowSettingsList(28) = New Setting("DataInterfaces", CStr(ItemsSelected.DataInterfaces))
            AssetWindowSettingsList(29) = New Setting("CapT2Components", CStr(ItemsSelected.CapT2Components))
            AssetWindowSettingsList(30) = New Setting("CapitalComponents", CStr(ItemsSelected.CapitalComponents))
            AssetWindowSettingsList(31) = New Setting("Components", CStr(ItemsSelected.Components))
            AssetWindowSettingsList(32) = New Setting("Hybrid", CStr(ItemsSelected.Hybrid))
            AssetWindowSettingsList(33) = New Setting("FuelBlocks", CStr(ItemsSelected.FuelBlocks))
            AssetWindowSettingsList(34) = New Setting("T1", CStr(ItemsSelected.T1))
            AssetWindowSettingsList(35) = New Setting("T2", CStr(ItemsSelected.T2))
            AssetWindowSettingsList(36) = New Setting("T3", CStr(ItemsSelected.T3))
            AssetWindowSettingsList(37) = New Setting("Faction", CStr(ItemsSelected.Faction))
            AssetWindowSettingsList(38) = New Setting("Pirate", CStr(ItemsSelected.Pirate))
            AssetWindowSettingsList(39) = New Setting("Storyline", CStr(ItemsSelected.Storyline))
            AssetWindowSettingsList(40) = New Setting("Asteroids", CStr(ItemsSelected.Asteroids))
            AssetWindowSettingsList(41) = New Setting("Misc", CStr(ItemsSelected.Misc))
            AssetWindowSettingsList(42) = New Setting("ItemFilterText", CStr(ItemsSelected.ItemFilterText))
            AssetWindowSettingsList(43) = New Setting("AllItems", CStr(ItemsSelected.AllItems))

            ' Main window
            AssetWindowSettingsList(44) = New Setting("AssetType", CStr(ItemsSelected.AssetType))
            AssetWindowSettingsList(45) = New Setting("SortbyName", CStr(ItemsSelected.SortbyName))

            AssetWindowSettingsList(46) = New Setting("Celestials", CStr(ItemsSelected.Celestials))
            AssetWindowSettingsList(47) = New Setting("Deployables", CStr(ItemsSelected.Deployables))
            AssetWindowSettingsList(48) = New Setting("Implants", CStr(ItemsSelected.Implants))
            AssetWindowSettingsList(49) = New Setting("BPCs", CStr(ItemsSelected.BPCs))
            AssetWindowSettingsList(50) = New Setting("StructureModules", CStr(ItemsSelected.StructureModules))
            AssetWindowSettingsList(51) = New Setting("AbyssalMaterials", CStr(ItemsSelected.AbyssalMaterials))

            AssetWindowSettingsList(52) = New Setting("StructureComponents", CStr(ItemsSelected.StructureComponents))

            Call WriteSettingsToFile(SettingsFolder, AssetWindowFileName, AssetWindowSettingsList, AssetWindowFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Asset Window Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetAssetWindowSettings(Location As AssetWindow) As AssetWindowSettings

        Select Case Location
            Case AssetWindow.ManufacturingTab
                Return AssetWindowSettingsManufacturingTab
            Case AssetWindow.ShoppingList
                Return AssetWindowSettingsShoppingList
            Case Else
                Return Nothing
        End Select

    End Function

    Public Function SetDefaultAssetWindowSettings(Location As AssetWindow) As AssetWindowSettings
        Dim LocalSettings As AssetWindowSettings = Nothing

        With LocalSettings
            .AssetType = DefaultAssetType
            .SortbyName = DefaultAssetSortbyName

            .ItemFilterText = DefaultAssetItemTextFilter
            .AllItems = DefaultAllItems
            .AllRawMats = DefaultAssetItemChecks
            .Minerals = DefaultAssetItemChecks
            .IceProducts = DefaultAssetItemChecks
            .Gas = DefaultAssetItemChecks
            .AbyssalMaterials = DefaultAssetItemChecks
            .Misc = DefaultAssetItemChecks
            .BPCs = DefaultAssetItemChecks
            .AncientRelics = DefaultAssetItemChecks
            .AncientSalvage = DefaultAssetItemChecks
            .Salvage = DefaultAssetItemChecks
            .StructureRigs = DefaultAssetItemChecks
            .StructureModules = DefaultAssetItemChecks
            .Planetary = DefaultAssetItemChecks
            .Datacores = DefaultAssetItemChecks
            .Decryptors = DefaultAssetItemChecks
            .RawMats = DefaultAssetItemChecks
            .ProcessedMats = DefaultAssetItemChecks
            .AdvancedMats = DefaultAssetItemChecks
            .MatsandCompounds = DefaultAssetItemChecks
            .DroneComponents = DefaultAssetItemChecks
            .BoosterMats = DefaultAssetItemChecks
            .Polymers = DefaultAssetItemChecks
            .Asteroids = DefaultAssetItemChecks
            .AllManufacturedItems = DefaultAssetItemChecks
            .Ships = DefaultAssetItemChecks
            .Modules = DefaultAssetItemChecks
            .Drones = DefaultAssetItemChecks
            .Boosters = DefaultAssetItemChecks
            .Rigs = DefaultAssetItemChecks
            .Charges = DefaultAssetItemChecks
            .Subsystems = DefaultAssetItemChecks
            .Structures = DefaultAssetItemChecks
            .Tools = DefaultAssetItemChecks
            .DataInterfaces = DefaultAssetItemChecks
            .CapT2Components = DefaultAssetItemChecks
            .CapitalComponents = DefaultAssetItemChecks
            .Components = DefaultAssetItemChecks
            .Hybrid = DefaultAssetItemChecks
            .StructureComponents = DefaultAssetItemChecks
            .FuelBlocks = DefaultAssetItemChecks
            .T1 = DefaultAssetItemChecks
            .T2 = DefaultAssetItemChecks
            .T3 = DefaultAssetItemChecks
            .Faction = DefaultAssetItemChecks
            .Pirate = DefaultAssetItemChecks
            .Storyline = DefaultAssetItemChecks
            .Celestials = DefaultAssetItemChecks
            .Deployables = DefaultAssetItemChecks
            .Implants = DefaultAssetItemChecks
        End With

        ' Save locally - Will have more than one
        Select Case Location
            Case AssetWindow.ManufacturingTab
                AssetWindowSettingsManufacturingTab = LocalSettings
            Case AssetWindow.ShoppingList
                AssetWindowSettingsShoppingList = LocalSettings
        End Select

        Return LocalSettings

    End Function

#End Region

#Region "LP Store Settings"

    ' Loads the tab settings
    Public Function LoadLPStoreSettings() As LPStore
        Dim TempSettings As LPStore = Nothing

        Try

            If FileExists(SettingsFolder, LPStoreSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .RewardType = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "RewardType", DefaultLPRewardType))
                    .CheckAgentLevel1 = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "CheckAgentLevel1", DefaultLPCheckAgentLevel1))
                    .CheckAgentLevel2 = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "CheckAgentLevel2", DefaultLPCheckAgentLevel2))
                    .CheckAgentLevel3 = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "CheckAgentLevel3", DefaultLPCheckAgentLevel3))
                    .CheckAgentLevel4 = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "CheckAgentLevel4", DefaultLPCheckAgentLevel4))
                    .CheckAgentLevel5 = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "CheckAgentLevel5", DefaultLPCheckAgentLevel5))
                    .TextItemSearch = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "TextItemSearch", DefaultLPTextItemSearch))
                    .LPCostLessThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "LPCostLessThan", DefaultLPLPCostLessThan))
                    .LPCostGreaterThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "LPCostGreaterThan", DefaultLPLPCostGreaterThan))
                    .ISKCostLessThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "ISKCostLessThan", DefaultLPISKCostLessThan))
                    .ISKCostGreaterThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "ISKCostGreaterThan", DefaultLPISKCostGreaterThan))
                    .StandingLessThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "StandingLessThan", DefaultLPStandingLessThan))
                    .StandingGreaterThan = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "StandingGreaterThan", DefaultLPStandingGreaterThan))
                    .SearchOption = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "SearchOption", DefaultLPSearchOption))
                    .HighlightCheck = CBool(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeBoolean, LPStoreSettingsFileName, "HighlightCheck", DefaultLPHighlightCheck))
                    .SelectedCorporations = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "SelectedCorporations", DefaultLPSelectedCorporations))
                    .SortByOption = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "SortByOption", DefaultLPSortByOption))
                    .CorpFilter = CStr(GetSettingValue(SettingsFolder, LPStoreSettingsFileName, SettingTypes.TypeString, LPStoreSettingsFileName, "CorpFilter", DefaultLPCorpFilter))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultLPStoreSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading LPStore Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultLPStoreSettings()
        End Try

        ' Save them locally and then export
        LPStoreSettings = TempSettings

        Return TempSettings

    End Function

    Public Function SetDefaultLPStoreSettings() As LPStore
        Dim LocalSettings As LPStore

        With LocalSettings
            .RewardType = DefaultLPRewardType
            .CorpFilter = DefaultLPCorpFilter
            .CheckAgentLevel1 = DefaultLPCheckAgentLevel1
            .CheckAgentLevel2 = DefaultLPCheckAgentLevel2
            .CheckAgentLevel3 = DefaultLPCheckAgentLevel3
            .CheckAgentLevel4 = DefaultLPCheckAgentLevel4
            .CheckAgentLevel5 = DefaultLPCheckAgentLevel5
            .TextItemSearch = DefaultLPTextItemSearch
            .LPCostLessThan = DefaultLPLPCostLessThan
            .LPCostGreaterThan = DefaultLPLPCostGreaterThan
            .ISKCostLessThan = DefaultLPISKCostLessThan
            .ISKCostGreaterThan = DefaultLPISKCostGreaterThan
            .StandingLessThan = DefaultLPStandingLessThan
            .StandingGreaterThan = DefaultLPStandingGreaterThan
            .SearchOption = DefaultLPSearchOption
            .HighlightCheck = DefaultLPHighlightCheck
            .SelectedCorporations = DefaultLPSelectedCorporations
            .SortByOption = DefaultLPSortByOption
        End With

        ' Save locally
        LPStoreSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveLPStoreSettings(SentSettings As LPStore)
        Dim LPStoreSettingsList(17) As Setting

        Try
            LPStoreSettingsList(0) = New Setting("RewardType", CStr(SentSettings.RewardType))
            LPStoreSettingsList(1) = New Setting("CheckAgentLevel1", CStr(SentSettings.CheckAgentLevel1))
            LPStoreSettingsList(2) = New Setting("CheckAgentLevel2", CStr(SentSettings.CheckAgentLevel2))
            LPStoreSettingsList(3) = New Setting("CheckAgentLevel3", CStr(SentSettings.CheckAgentLevel3))
            LPStoreSettingsList(4) = New Setting("CheckAgentLevel4", CStr(SentSettings.CheckAgentLevel4))
            LPStoreSettingsList(5) = New Setting("CheckAgentLevel5", CStr(SentSettings.CheckAgentLevel5))
            LPStoreSettingsList(6) = New Setting("TextItemSearch", CStr(SentSettings.TextItemSearch))
            LPStoreSettingsList(7) = New Setting("LPCostLessThan", CStr(SentSettings.LPCostLessThan))
            LPStoreSettingsList(8) = New Setting("LPCostGreaterThan", CStr(SentSettings.LPCostGreaterThan))
            LPStoreSettingsList(9) = New Setting("ISKCostLessThan", CStr(SentSettings.ISKCostLessThan))
            LPStoreSettingsList(10) = New Setting("ISKCostGreaterThan", CStr(SentSettings.ISKCostGreaterThan))
            LPStoreSettingsList(11) = New Setting("StandingLessThan", CStr(SentSettings.StandingLessThan))
            LPStoreSettingsList(12) = New Setting("StandingGreaterThan", CStr(SentSettings.StandingGreaterThan))
            LPStoreSettingsList(13) = New Setting("SearchOption", CStr(SentSettings.SearchOption))
            LPStoreSettingsList(14) = New Setting("HighlightCheck", CStr(SentSettings.HighlightCheck))
            LPStoreSettingsList(15) = New Setting("SelectedCorporations", CStr(SentSettings.SelectedCorporations))
            LPStoreSettingsList(16) = New Setting("SortByOption", CStr(SentSettings.SortByOption))
            LPStoreSettingsList(17) = New Setting("CorpFilter", CStr(SentSettings.CorpFilter))

            Call WriteSettingsToFile(SettingsFolder, LPStoreSettingsFileName, LPStoreSettingsList, LPStoreSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving LP Store Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetLPStoreSettings() As LPStore
        Return LPStoreSettings
    End Function

#End Region

#Region "Market History Viewer Settings"

    ' Loads the tab settings
    Public Function LoadMarketHistoryViewerSettingsSettings() As MarketHistoryViewerSettings
        Dim TempSettings As MarketHistoryViewerSettings = Nothing

        Try

            If FileExists(SettingsFolder, MarketHistoryViewerSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .DatePreference = CStr(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeString, MarketHistoryViewerSettingsFileName, "DatePreference", DefaultMHDatePreference))
                    .Volume = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "Volume", DefaultMHVolume))
                    .MinMaxDayPrice = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "MinMaxDayPrice", DefaultMHMinMaxDayPrice))
                    .LinearTrend = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "LinearTrend", DefaultMHLinearTrend))
                    .DochianChannel = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "DochianChannel", DefaultMHDochianChannel))
                    .FiveDayAvg = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "FiveDayAvg", DefaultMHFiveDayAvg))
                    .TwentyDayAvg = CBool(GetSettingValue(SettingsFolder, MarketHistoryViewerSettingsFileName, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "TwentyDayAvg", DefaultMHTwentyDayAvg))
                End With
            Else
                ' Load defaults 
                TempSettings = SetDefaultMarketHistoryViewerSettingsSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading MarketHistoryViewerSettings Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultMarketHistoryViewerSettingsSettings()
        End Try

        ' Save them locally and then export
        MarketHistoryViewSettings = TempSettings

        Return TempSettings

    End Function

    Public Function SetDefaultMarketHistoryViewerSettingsSettings() As MarketHistoryViewerSettings
        Dim LocalSettings As MarketHistoryViewerSettings

        With LocalSettings
            .DatePreference = DefaultMHDatePreference
            .Volume = DefaultMHVolume
            .MinMaxDayPrice = DefaultMHMinMaxDayPrice
            .LinearTrend = DefaultMHLinearTrend
            .DochianChannel = DefaultMHDochianChannel
            .FiveDayAvg = DefaultMHFiveDayAvg
            .TwentyDayAvg = DefaultMHTwentyDayAvg
        End With

        ' Save locally
        MarketHistoryViewSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveMarketHistoryViewerSettingsSettings(SentSettings As MarketHistoryViewerSettings)
        Dim MarketHistoryViewerSettingsSettingsList(6) As Setting

        Try
            MarketHistoryViewerSettingsSettingsList(0) = New Setting("DatePreference", CStr(SentSettings.DatePreference))
            MarketHistoryViewerSettingsSettingsList(1) = New Setting("MinMaxDayPrice", CStr(SentSettings.MinMaxDayPrice))
            MarketHistoryViewerSettingsSettingsList(2) = New Setting("Volume", CStr(SentSettings.Volume))
            MarketHistoryViewerSettingsSettingsList(3) = New Setting("LinearTrend", CStr(SentSettings.LinearTrend))
            MarketHistoryViewerSettingsSettingsList(4) = New Setting("DochianChannel", CStr(SentSettings.DochianChannel))
            MarketHistoryViewerSettingsSettingsList(5) = New Setting("FiveDayAvg", CStr(SentSettings.FiveDayAvg))
            MarketHistoryViewerSettingsSettingsList(6) = New Setting("TwentyDayAvg", CStr(SentSettings.TwentyDayAvg))

            Call WriteSettingsToFile(SettingsFolder, MarketHistoryViewerSettingsFileName, MarketHistoryViewerSettingsSettingsList, MarketHistoryViewerSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving LP Store Tab Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetMarketHistoryViewerSettingsSettings() As MarketHistoryViewerSettings
        Return MarketHistoryViewSettings
    End Function

#End Region

#Region "BP Viewer Settings"

    ' Loads the tab settings
    Public Function LoadBPViewerSettings() As BPViewerSettings
        Dim TempSettings As BPViewerSettings = Nothing

        Try
            If FileExists(SettingsFolder, BPViewerSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .BlueprintTypeSelection = CStr(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeString, BPViewerSettingsFileName, "BlueprintTypeSelection", DefaultBPViewerSelectionType))
                    .Tech1Check = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech1Check", DefaultBPViewerTechChecks))
                    .Tech2Check = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech2Check", DefaultBPViewerTechChecks))
                    .Tech3Check = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech3Check", DefaultBPViewerTechChecks))
                    .TechStorylineCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechStorylineCheck", DefaultBPViewerTechChecks))
                    .TechFactionCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechFactionCheck", DefaultBPViewerTechChecks))
                    .TechPirateCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechPirateCheck", DefaultBPViewerTechChecks))
                    .SmallCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks))
                    .MediumCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks))
                    .LargeCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks))
                    .XLCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks))
                    .IncludeIgnoredBPs = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "IncludeIgnoredBPs", DefaultBPViewerIgnoreBPsCheck))
                    .BPNPCBPOsCheck = CBool(GetSettingValue(SettingsFolder, BPViewerSettingsFileName, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "BPNPCBPOsCheck", DefaultBPNPCBPOsCheck))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultBPViewerSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading BP Viewer Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultBPViewerSettings()
        End Try

        ' Save them locally and then export
        BPViewSettings = TempSettings

        Return TempSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveBPViewerSettings(SentSettings As BPViewerSettings)
        Dim BPSettingsList(12) As Setting

        Try
            BPSettingsList(0) = New Setting("BlueprintTypeSelection", CStr(SentSettings.BlueprintTypeSelection))
            BPSettingsList(1) = New Setting("Tech1Check", CStr(SentSettings.Tech1Check))
            BPSettingsList(2) = New Setting("Tech2Check", CStr(SentSettings.Tech2Check))
            BPSettingsList(3) = New Setting("Tech3Check", CStr(SentSettings.Tech3Check))
            BPSettingsList(4) = New Setting("TechStorylineCheck", CStr(SentSettings.TechStorylineCheck))
            BPSettingsList(5) = New Setting("TechFactionCheck", CStr(SentSettings.TechFactionCheck))
            BPSettingsList(6) = New Setting("TechPirateCheck", CStr(SentSettings.TechPirateCheck))
            BPSettingsList(7) = New Setting("SmallCheck", CStr(SentSettings.SmallCheck))
            BPSettingsList(8) = New Setting("MediumCheck", CStr(SentSettings.MediumCheck))
            BPSettingsList(9) = New Setting("LargeCheck", CStr(SentSettings.LargeCheck))
            BPSettingsList(10) = New Setting("XLCheck", CStr(SentSettings.XLCheck))
            BPSettingsList(11) = New Setting("IncludeIgnoredBPs", CStr(SentSettings.IncludeIgnoredBPs))
            BPSettingsList(12) = New Setting("BPNPCBPOsCheck", CStr(SentSettings.BPNPCBPOsCheck))

            Call WriteSettingsToFile(SettingsFolder, BPSettingsFileName, BPSettingsList, BPSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving BP Viewer Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Loads the defaults
    Public Function SetDefaultBPViewerSettings() As BPViewerSettings
        Dim LocalSettings As BPViewerSettings

        With LocalSettings
            .BPNPCBPOsCheck = DefaultBPNPCBPOsCheck
            .BlueprintTypeSelection = DefaultBPViewerSelectionType
            .Tech1Check = DefaultBPViewerTechChecks
            .Tech2Check = DefaultBPViewerTechChecks
            .Tech3Check = DefaultBPViewerTechChecks
            .TechStorylineCheck = DefaultBPViewerTechChecks
            .TechFactionCheck = DefaultBPViewerTechChecks
            .TechPirateCheck = DefaultBPViewerTechChecks
            .SmallCheck = DefaultBPViewerSizeChecks
            .MediumCheck = DefaultBPViewerSizeChecks
            .LargeCheck = DefaultBPViewerSizeChecks
            .XLCheck = DefaultBPViewerSizeChecks
            .IncludeIgnoredBPs = DefaultBPViewerIgnoreBPsCheck
        End With

        ' Save locally
        BPViewSettings = LocalSettings

        Return LocalSettings

    End Function

    ' Returns the tab settings
    Public Function GetBPViewerSettings() As BPViewerSettings
        Return BPViewSettings
    End Function

#End Region

#Region "Upwell Structures Viewer Settings"

    ' Loads the tab settings
    Public Function LoadUpwellStructureViewerSettings() As UpwellStructureSettings
        Dim TempSettings As UpwellStructureSettings = Nothing

        Try

            If FileExists(SettingsFolder, UpwellStructureViewerSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .HighSlotsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "HighSlotsCheck", DefaultHighSlotsCheck))
                    .MediumSlotsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "MediumSlotsCheck", DefaultMediumSlotsCheck))
                    .LowSlotsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "LowSlotsCheck", DefaultLowSlotsCheck))
                    .ServicesCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ServicesCheck", DefaultServicesCheck))
                    .ReprocessingRigsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ReprocessingRigsCheck", DefaultReprocessingRigsCheck))
                    .EngineeringRigsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "EngineeringRigsCheck", DefaultEngineeringRigsCheck))
                    .CombatRigsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "CombatRigsCheck", DefaultCombatRigsCheck))
                    .IncludeFuelCostsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "IncludeFuelCostsCheck", DefaultIncludeFuelCostsCheck))
                    .FuelBlockType = CStr(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "FuelBlockType", DefaultFuelBlockType))
                    .BuyBuildBlockOption = CStr(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "BuyBuildBlockOption", DefaultBuyBuildBlockOption))
                    .AutoUpdateFuelBlockPricesCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "AutoUpdateFuelBlockPricesCheck", DefaultAutoUpdateFuelBlockPricesCheck))
                    .SearchFilterText = CStr(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "SearchFilterText", DefaultSearchFilterText))
                    .SelectedStructureName = CStr(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "SelectedStructureName", DefaultSelectedStructureName))
                    .ReactionsRigsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ReactionsRigsCheck", DefaultReactionsRigsCheck))
                    .DrillingRigsCheck = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "DrillingRigsCheck", DefaultDrillingRigsCheck))
                    .IconListView = CBool(GetSettingValue(SettingsFolder, UpwellStructureViewerSettingsFileName, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "IconListView", DefaultIconListView))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultUpwellStructureViewerSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading UpwellStructureViewer Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultUpwellStructureViewerSettings()
        End Try

        ' Save them locally and then export
        UpwellStructureViewerSettings = TempSettings

        Return TempSettings

    End Function

    Public Function SetDefaultUpwellStructureViewerSettings() As UpwellStructureSettings
        Dim LocalSettings As UpwellStructureSettings

        With LocalSettings
            .HighSlotsCheck = DefaultHighSlotsCheck
            .MediumSlotsCheck = DefaultMediumSlotsCheck
            .LowSlotsCheck = DefaultLowSlotsCheck
            .ServicesCheck = DefaultServicesCheck
            .ReprocessingRigsCheck = DefaultReprocessingRigsCheck
            .EngineeringRigsCheck = DefaultEngineeringRigsCheck
            .CombatRigsCheck = DefaultCombatRigsCheck
            .IncludeFuelCostsCheck = DefaultIncludeFuelCostsCheck
            .FuelBlockType = DefaultFuelBlockType
            .BuyBuildBlockOption = DefaultBuyBuildBlockOption
            .AutoUpdateFuelBlockPricesCheck = DefaultAutoUpdateFuelBlockPricesCheck
            .SearchFilterText = DefaultSearchFilterText
            .SelectedStructureName = DefaultSelectedStructureName
            .ReactionsRigsCheck = DefaultReactionsRigsCheck
            .DrillingRigsCheck = DefaultDrillingRigsCheck
            .IconListView = DefaultIconListView
        End With

        ' Save locally
        UpwellStructureViewerSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveUpwellStructureViewerSettings(SentSettings As UpwellStructureSettings)
        Dim UpwellStructureViewerSettingsList(15) As Setting

        Try
            UpwellStructureViewerSettingsList(0) = New Setting("HighSlotsCheck", CStr(SentSettings.HighSlotsCheck))
            UpwellStructureViewerSettingsList(1) = New Setting("MediumSlotsCheck", CStr(SentSettings.MediumSlotsCheck))
            UpwellStructureViewerSettingsList(2) = New Setting("LowSlotsCheck", CStr(SentSettings.LowSlotsCheck))
            UpwellStructureViewerSettingsList(3) = New Setting("ServicesCheck", CStr(SentSettings.ServicesCheck))
            UpwellStructureViewerSettingsList(4) = New Setting("ReprocessingRigsCheck", CStr(SentSettings.ReprocessingRigsCheck))
            UpwellStructureViewerSettingsList(5) = New Setting("EngineeringRigsCheck", CStr(SentSettings.EngineeringRigsCheck))
            UpwellStructureViewerSettingsList(6) = New Setting("CombatRigsCheck", CStr(SentSettings.CombatRigsCheck))
            UpwellStructureViewerSettingsList(7) = New Setting("IncludeFuelCostsCheck", CStr(SentSettings.IncludeFuelCostsCheck))
            UpwellStructureViewerSettingsList(8) = New Setting("FuelBlockType", CStr(SentSettings.FuelBlockType))
            UpwellStructureViewerSettingsList(9) = New Setting("BuyBuildBlockOption", CStr(SentSettings.BuyBuildBlockOption))
            UpwellStructureViewerSettingsList(10) = New Setting("AutoUpdateFuelBlockPricesCheck", CStr(SentSettings.AutoUpdateFuelBlockPricesCheck))
            UpwellStructureViewerSettingsList(11) = New Setting("SearchFilterText", CStr(SentSettings.SearchFilterText))
            UpwellStructureViewerSettingsList(12) = New Setting("SelectedStructureName", CStr(SentSettings.SelectedStructureName))
            UpwellStructureViewerSettingsList(13) = New Setting("ReactionsRigsCheck", CStr(SentSettings.ReactionsRigsCheck))
            UpwellStructureViewerSettingsList(14) = New Setting("DrillingRigsCheck", CStr(SentSettings.DrillingRigsCheck))
            UpwellStructureViewerSettingsList(15) = New Setting("IconListView", CStr(SentSettings.IconListView))

            Call WriteSettingsToFile(SettingsFolder, UpwellStructureViewerSettingsFileName, UpwellStructureViewerSettingsList, UpwellStructureViewerSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Upwell Structures Viewer Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetUpwellStructureViewerSettings() As UpwellStructureSettings
        Return UpwellStructureViewerSettings
    End Function

#End Region

#Region "Bonus Popup Settings"

    ' Loads the tab settings
    Public Function LoadStructureBonusPopoutViewerSettings() As StructureBonusPopoutSettings
        Dim TempSettings As StructureBonusPopoutSettings = Nothing

        Try

            If FileExists(SettingsFolder, StructureBonusPopoutViewerSettingsFileName) Then
                'Get the settings
                With TempSettings
                    .FormHeight = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "FormHeight", DefaultSBPVFormHeight))
                    .FormWidth = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "FormWidth", DefaultSBPVFormWidth))
                    .ActivityColumnWidth = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "ActivityColumnWidth", DefaultSBPVActivityColumnWidth))
                    .BonusAppliesColumnWidth = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusAppliesColumnWidth", DefaultSBPVBonusAppliesColumnWidth))
                    .BonusesColumnWidth = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusesColumnWidth", DefaultSBPVBonusesColumnWidth))
                    .BonusSourceColumnWidth = CInt(GetSettingValue(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusSourceColumnWidth", DefaultSBPVBonusSourceColumnWidth))
                End With

            Else
                ' Load defaults 
                TempSettings = SetDefaultStructureBonusPopoutViewerSettings()
            End If

        Catch ex As Exception
            MsgBox("An error occured when loading UpwellStructureViewer Settings. Error: " & Err.Description & vbCrLf & "Default settings were loaded.", vbExclamation, Application.ProductName)
            ' Load defaults 
            TempSettings = SetDefaultStructureBonusPopoutViewerSettings()
        End Try

        ' Save them locally and then export
        StructureBonusPopoutViewerSettings = TempSettings

        Return TempSettings

    End Function

    Public Function SetDefaultStructureBonusPopoutViewerSettings() As StructureBonusPopoutSettings
        Dim LocalSettings As StructureBonusPopoutSettings

        With LocalSettings
            .FormHeight = DefaultSBPVFormHeight
            .FormWidth = DefaultSBPVFormWidth
            .ActivityColumnWidth = DefaultSBPVActivityColumnWidth
            .BonusAppliesColumnWidth = DefaultSBPVBonusAppliesColumnWidth
            .BonusesColumnWidth = DefaultSBPVBonusesColumnWidth
            .BonusSourceColumnWidth = DefaultSBPVBonusSourceColumnWidth
        End With

        ' Save locally
        StructureBonusPopoutViewerSettings = LocalSettings
        Return LocalSettings

    End Function

    ' Saves the tab settings to XML
    Public Sub SaveStructureBonusPopoutViewerSettings(SentSettings As StructureBonusPopoutSettings)
        Dim StructureBonusPopoutViewerSettingsList(5) As Setting

        Try
            StructureBonusPopoutViewerSettingsList(0) = New Setting("FormHeight", CStr(SentSettings.FormHeight))
            StructureBonusPopoutViewerSettingsList(1) = New Setting("FormWidth", CStr(SentSettings.FormWidth))
            StructureBonusPopoutViewerSettingsList(2) = New Setting("ActivityColumnWidth", CStr(SentSettings.ActivityColumnWidth))
            StructureBonusPopoutViewerSettingsList(3) = New Setting("BonusAppliesColumnWidth", CStr(SentSettings.BonusAppliesColumnWidth))
            StructureBonusPopoutViewerSettingsList(4) = New Setting("BonusesColumnWidth", CStr(SentSettings.BonusesColumnWidth))
            StructureBonusPopoutViewerSettingsList(5) = New Setting("BonusSourceColumnWidth", CStr(SentSettings.BonusSourceColumnWidth))

            Call WriteSettingsToFile(SettingsFolder, StructureBonusPopoutViewerSettingsFileName, StructureBonusPopoutViewerSettingsList, StructureBonusPopoutViewerSettingsFileName)

        Catch ex As Exception
            MsgBox("An error occured when saving Upwell Structures Viewer Settings. Error: " & Err.Description & vbCrLf & "Settings not saved.", vbExclamation, Application.ProductName)
        End Try

    End Sub

    ' Returns the tab settings
    Public Function GetStructureBonusPopoutViewerSettings() As StructureBonusPopoutSettings
        Return StructureBonusPopoutViewerSettings
    End Function

#End Region

End Class

' For general program settings
Public Structure ApplicationSettings
    Dim CheckforUpdatesonStart As Boolean
    Dim DataExportFormat As String
    Dim AllowSkillOverride As Boolean
    Dim ShowToolTips As Boolean

    Dim RefiningImplantValue As Double
    Dim ManufacturingImplantValue As Double
    Dim CopyImplantValue As Double

    Dim LoadAssetsonStartup As Boolean
    Dim LoadBPsonStartup As Boolean
    Dim LoadESIMarketDataonStartup As Boolean
    Dim LoadESISystemCostIndiciesDataonStartup As Boolean
    Dim LoadESIPublicStructuresonStartup As Boolean
    Dim SupressESIStatusMessages As Boolean
    Dim DisableSound As Boolean
    Dim IncludeInGameLinksinCopyText As Boolean

    Dim SaveFacilitiesbyChar As Boolean
    Dim LoadBPsbyChar As Boolean

    ' Station Standings for building and selling
    Dim BrokerCorpStanding As Double
    Dim BrokerFactionStanding As Double

    ' ME/TE for BP's we don't own or haven't entered info for
    Dim DefaultBPME As Integer
    Dim DefaultBPTE As Integer

    ' For Build/Buy 
    Dim CheckBuildBuy As Boolean ' Default for setting the check box for build/buy on the blueprints screen
    Dim SuggestBuildBPNotOwned As Boolean ' For Build/Buy suggestions
    Dim SaveBPRelicsDecryptors As Boolean ' For auto-loading relics and decryptor types

    Dim DisableSVR As Boolean ' For disabling SVR updates
    Dim DisableGATracking As Boolean ' for disabling tracking app usage through Google Analytics

    Dim ShareSavedFacilities As Boolean ' to use the same facility everywhere

    ' Character options
    Dim AlphaAccount As Boolean ' Check to determine if they are using an alpha account or not
    Dim UseActiveSkillLevels As Boolean ' Use active skill levels instead of trained - useful for omega on alpha currently
    Dim LoadMaxAlphaSkills As Boolean ' Load the max alpha skills for dummy accounts

    ' For shopping list
    Dim ShopListIncludeInventMats As Boolean
    Dim ShopListIncludeCopyMats As Boolean

    ' The interval for allowing refresh of prices from EVE Central - no less than 1 hour
    Dim EVEMarketerRefreshInterval As Integer

    ' Filter variables for svr
    Dim IgnoreSVRThresholdValue As Double
    Dim SVRAveragePriceRegion As String
    Dim SVRAveragePriceDuration As String
    Dim AutoUpdateSVRonBPTab As Boolean

    Dim ProxyAddress As String
    Dim ProxyPort As Integer

End Structure

Public Enum BuildMatType
    AdvMaterials = 1
    ProcessedMaterials = 2
    RawMaterials = 3
End Enum

' For BP Tab Settings
Public Structure BPTabSettings
    ' Form stuff
    Dim BlueprintTypeSelection As String
    Dim Tech1Check As Boolean
    Dim Tech2Check As Boolean
    Dim Tech3Check As Boolean
    Dim TechStorylineCheck As Boolean
    Dim TechFactionCheck As Boolean
    Dim TechPirateCheck As Boolean
    Dim IncludeIgnoredBPs As Boolean

    Dim SmallCheck As Boolean
    Dim MediumCheck As Boolean
    Dim LargeCheck As Boolean
    Dim XLCheck As Boolean

    Dim IncludeFees As Integer ' 0,1,2 - Tri check
    Dim BrokerFeeRate As Double
    Dim IncludeUsage As Boolean
    Dim IncludeTaxes As Boolean

    Dim IncludeInventionCost As Boolean
    Dim IncludeInventionTime As Boolean
    Dim IncludeCopyCost As Boolean
    Dim IncludeCopyTime As Boolean
    Dim IncludeT3Cost As Boolean
    Dim IncludeT3Time As Boolean

    Dim PricePerUnit As Boolean

    Dim SimpleCopyCheck As Boolean
    Dim NPCBPOs As Boolean

    Dim ProductionLines As Integer
    Dim LaboratoryLines As Integer
    Dim T3Lines As Integer

    Dim T2DecryptorType As String
    Dim RelicType As String
    Dim T3DecryptorType As String

    Dim IgnoreInvention As Boolean
    Dim IgnoreMinerals As Boolean
    Dim IgnoreT1Item As Boolean

    Dim ExporttoShoppingListType As String

    Dim RawColumnSort As Integer
    Dim RawColumnSortType As String
    Dim CompColumnSort As Integer
    Dim CompColumnSortType As String

    Dim RawProfitType As String
    Dim CompProfitType As String

    Dim CompressedOre As Boolean

    Dim SellExcessBuildItems As Boolean

    Dim BuildT2T3Materials As BuildMatType ' How they want to build T2/T3 items (BuildMatType) - BP Tab

End Structure

' For the Market Viewer
Public Structure MarketHistoryViewerSettings
    Dim DatePreference As String

    Dim Volume As Boolean
    Dim MinMaxDayPrice As Boolean

    Dim LinearTrend As Boolean
    Dim DochianChannel As Boolean
    Dim FiveDayAvg As Boolean
    Dim TwentyDayAvg As Boolean

End Structure

' For Update Price Settings
Public Structure UpdatePriceTabSettings
    Dim AllRawMats As Boolean
    Dim Minerals As Boolean
    Dim IceProducts As Boolean
    Dim Gas As Boolean
    Dim AbyssalMaterials As Boolean
    Dim BPCs As Boolean
    Dim Misc As Boolean
    Dim AncientRelics As Boolean
    Dim AncientSalvage As Boolean
    Dim Salvage As Boolean
    Dim Planetary As Boolean
    Dim Datacores As Boolean
    Dim Decryptors As Boolean
    Dim RawMats As Boolean
    Dim ProcessedMats As Boolean
    Dim AdvancedMats As Boolean
    Dim MatsandCompounds As Boolean
    Dim DroneComponents As Boolean
    Dim BoosterMats As Boolean
    Dim Polymers As Boolean
    Dim Asteroids As Boolean

    Dim AllManufacturedItems As Boolean
    Dim Ships As Boolean
    Dim Charges As Boolean
    Dim Modules As Boolean
    Dim Drones As Boolean
    Dim Rigs As Boolean
    Dim Deployables As Boolean
    Dim Subsystems As Boolean
    Dim Boosters As Boolean
    Dim Structures As Boolean
    Dim Celestials As Boolean
    Dim StationComponents As Boolean
    Dim StructureModules As Boolean
    Dim Tools As Boolean
    Dim FuelBlocks As Boolean
    Dim Implants As Boolean
    Dim CapT2Components As Boolean
    Dim CapitalComponents As Boolean
    Dim Components As Boolean
    Dim Hybrid As Boolean
    Dim StructureComponents As Boolean

    Dim T1 As Boolean
    Dim T2 As Boolean
    Dim T3 As Boolean
    Dim Faction As Boolean
    Dim Pirate As Boolean
    Dim Storyline As Boolean

    Dim SelectedRegions As List(Of String) ' Could have several
    Dim SelectedSystem As String

    ' The default price profile settings
    Dim PPRawPriceType As String
    Dim PPRawRegion As String
    Dim PPRawSystem As String
    Dim PPRawPriceMod As Double
    Dim PPItemsPriceType As String
    Dim PPItemsRegion As String
    Dim PPItemsSystem As String
    Dim PPItemsPriceMod As Double

    ' For two price types
    Dim ItemsCombo As String
    Dim RawMatsCombo As String

    Dim ItemsPriceModifier As Double
    Dim RawPriceModifier As Double

    Dim UseESIData As Boolean
    Dim UsePriceProfile As Boolean

    Dim ColumnSort As Integer
    Dim ColumnSortType As String

End Structure

' For Manufacturing Tab Settings
Public Structure ManufacturingTabSettings
    Dim BlueprintType As String

    Dim CheckTech1 As Boolean
    Dim CheckTech2 As Boolean
    Dim CheckTech3 As Boolean
    Dim CheckTechStoryline As Boolean
    Dim CheckTechNavy As Boolean
    Dim CheckTechPirate As Boolean

    Dim ItemTypeFilter As String
    Dim TextItemFilter As String

    Dim CheckBPTypeShips As Boolean
    Dim CheckBPTypeDrones As Boolean
    Dim CheckBPTypeComponents As Boolean
    Dim CheckBPTypeStructures As Boolean
    Dim CheckBPTypeMisc As Boolean
    Dim CheckBPTypeNPCBPOs As Boolean
    Dim CheckBPTypeModules As Boolean
    Dim CheckBPTypeAmmoCharges As Boolean
    Dim CheckBPTypeRigs As Boolean
    Dim CheckBPTypeSubsystems As Boolean
    Dim CheckBPTypeBoosters As Boolean
    Dim CheckBPTypeDeployables As Boolean
    Dim CheckBPTypeCelestials As Boolean
    Dim CheckBPTypeStructureModules As Boolean
    Dim CheckBPTypeStationParts As Boolean
    Dim CheckBPTypeReactions As Boolean

    Dim CheckCapitalComponentsFacility As Boolean
    Dim CheckT3DestroyerFacility As Boolean

    Dim CheckAutoCalcNumBPs As Boolean

    Dim CheckDecryptorNone As Boolean
    Dim CheckDecryptorOptimal As Integer ' Check State
    Dim CheckDecryptor06 As Boolean
    Dim CheckDecryptor09 As Boolean
    Dim CheckDecryptor10 As Boolean
    Dim CheckDecryptor11 As Boolean
    Dim CheckDecryptor12 As Boolean
    Dim CheckDecryptor15 As Boolean
    Dim CheckDecryptor18 As Boolean
    Dim CheckDecryptor19 As Boolean

    Dim CheckDecryptorUseforT2 As Boolean
    Dim CheckDecryptorUseforT3 As Boolean

    Dim CheckIgnoreInvention As Boolean

    Dim CheckRelicWrecked As Boolean
    Dim CheckRelicIntact As Boolean
    Dim CheckRelicMalfunction As Boolean

    Dim CheckOnlyBuild As Boolean
    Dim CheckOnlyInvent As Boolean

    Dim CheckIncludeTaxes As Boolean
    Dim CheckIncludeBrokersFees As Integer ' Tri check
    Dim CalcBrokerFeeRate As Double
    Dim CheckIncludeUsage As Boolean

    Dim CheckRaceAmarr As Boolean
    Dim CheckRaceCaldari As Boolean
    Dim CheckRaceGallente As Boolean
    Dim CheckRaceMinmatar As Boolean
    Dim CheckRacePirate As Boolean
    Dim CheckRaceOther As Boolean

    Dim PriceCompare As String

    Dim CheckIncludeT2Owned As Boolean
    Dim CheckIncludeT3Owned As Boolean

    ' Filter variables
    Dim CheckSVRIncludeNull As Boolean
    Dim Score As Integer
    Dim RiskProfit As Integer
    Dim RiskIPH As Integer
    Dim RiskPrice As Integer
    Dim Volatility As Integer
    Dim PriceTrend As String
    Dim MinBuildTime As String
    Dim MinBuildTimeCheck As Boolean
    Dim MaxBuildTime As String
    Dim MaxBuildTimeCheck As Boolean
    Dim IPHThreshold As Double
    Dim IPHThresholdCheck As Boolean
    Dim ProfitThreshold As Double
    Dim ProfitThresholdCheck As Integer
    Dim VolumeThreshold As Double
    Dim VolumeThresholdCheck As Boolean

    Dim ProductionLines As Integer
    Dim LaboratoryLines As Integer
    Dim Runs As Integer
    Dim BPRuns As Integer

    Dim CheckSmall As Boolean
    Dim CheckMedium As Boolean
    Dim CheckLarge As Boolean
    Dim CheckXL As Boolean

    Dim IgnoreInvention As Boolean
    Dim IgnoreMinerals As Boolean
    Dim IgnoreT1Item As Boolean

    Dim CalcPPU As Boolean
    Dim CheckSellExcessItems As Boolean

    Dim ManufacturingFWUpgradeLevel As String
    Dim CopyingFWUpgradeLevel As String
    Dim InventionFWUpgradeLevel As String

    Dim ColumnSort As Integer
    Dim ColumnSortType As String

    Dim BuildT2T3Materials As BuildMatType ' How they want to build T2/T3 items (BuildMatType) - BP Tab

End Structure

' For Datacore Tab Settings
Public Structure DataCoreTabSettings
    Dim PricesFrom As String

    Dim CheckHighSecAgents As Boolean
    Dim CheckLowNullSecAgents As Boolean
    Dim CheckIncludeAgentsCannotAccess As Boolean

    Dim AgentsInRegion As String

    Dim CheckSovAmarr As Boolean
    Dim CheckSovAmmatar As Boolean
    Dim CheckSovGallente As Boolean
    Dim CheckSovSyndicate As Boolean
    Dim CheckSovKhanid As Boolean
    Dim CheckSovThukker As Boolean
    Dim CheckSovCaldari As Boolean
    Dim CheckSovMinmatar As Boolean

    Dim SkillsChecked() As Integer
    Dim SkillsLevel() As Integer

    Dim CorpsChecked() As Integer
    Dim CorpsStanding() As Double

    Dim Connections As Integer
    Dim Negotiation As Integer
    Dim ResearchProjectMgt As Integer

    Dim ColumnSort As Integer
    Dim ColumnSortType As String

End Structure

' For Reaction Tab Settings
Public Structure ReactionsTabSettings
    Dim POSFuelCost As Double
    Dim NumberofPOS As Integer

    Dim CheckTaxes As Boolean
    Dim CheckFees As Boolean

    Dim CheckAdvMoonMats As Boolean
    Dim CheckProcessedMoonMats As Boolean
    Dim CheckHybrid As Boolean
    Dim CheckComplexBio As Boolean
    Dim CheckSimpleBio As Boolean

    Dim CheckBuildBasic As Boolean
    Dim CheckIgnoreMarket As Boolean
    Dim CheckRefine As Boolean

    Dim RefineryEfficiency As Double
    Dim RefineryTax As Double
    Dim RefineryStanding As Double

    Dim ColumnSort As Integer
    Dim ColumnSortType As String

End Structure

' For Mining Settings
Public Structure MiningTabSettings
    Dim OreType As String ' Ore or Ice

    Dim CheckHighYieldOres As Boolean
    Dim CheckHighSecOres As Boolean
    Dim CheckLowSecOres As Boolean
    Dim CheckNullSecOres As Boolean

    Dim CheckSovAmarr As Boolean
    Dim CheckSovCaldari As Boolean
    Dim CheckSovGallente As Boolean
    Dim CheckSovMinmatar As Boolean
    Dim CheckSovTriglavian As Boolean
    Dim CheckSovWormhole As Boolean
    Dim CheckSovMoon As Boolean
    Dim CheckSovC1 As Boolean
    Dim CheckSovC2 As Boolean
    Dim CheckSovC3 As Boolean
    Dim CheckSovC4 As Boolean
    Dim CheckSovC5 As Boolean
    Dim CheckSovC6 As Boolean

    Dim CheckIncludeFees As Boolean
    Dim CheckIncludeTaxes As Boolean
    Dim BrokerFeeRate As Double

    Dim CheckIncludeJumpFuelCosts As Boolean
    Dim TotalJumpFuelCost As Double
    Dim TotalJumpFuelM3 As Double
    Dim JumpCompressedOre As Boolean
    Dim JumpMinerals As Boolean

    Dim OreMiningShip As String
    Dim IceMiningShip As String
    Dim GasMiningShip As String
    Dim OreStrip As String
    Dim IceStrip As String
    Dim GasHarvester As String
    Dim NumOreMiners As Integer
    Dim NumIceMiners As Integer
    Dim NumGasHarvesters As Integer
    Dim OreUpgrade As String
    Dim IceUpgrade As String
    Dim GasUpgrade As String
    Dim NumOreUpgrades As Integer
    Dim NumIceUpgrades As Integer
    Dim NumGasUpgrades As Integer
    Dim OreImplant As String
    Dim IceImplant As String
    Dim GasImplant As String

    Dim MichiiImplant As Boolean
    Dim T2Crystals As Boolean

    Dim CheckUseHauler As Boolean
    Dim RoundTripMin As Integer
    Dim RoundTripSec As Integer
    Dim Haulerm3 As Double

    Dim CheckUseFleetBooster As Boolean
    Dim BoosterShip As String
    Dim BoosterShipSkill As Integer
    Dim MiningFormanSkill As Integer
    Dim MiningDirectorSkill As Integer
    Dim CheckMineForemanLaserOpBoost As Integer ' 0,1,2
    Dim CheckMineForemanLaserRangeBoost As Integer '0,1,2
    Dim CheckMiningForemanMindLink As Boolean

    Dim CheckRorqDeployed As Integer  '0,1,2
    Dim IndustrialReconfig As Integer

    Dim MiningDroneM3perHour As Double
    Dim NumberofMiners As Integer

    Dim RefinedOre As Boolean
    Dim UnrefinedOre As Boolean
    Dim CompressedOre As Boolean

    Dim MercoxitMiningRig As Boolean
    Dim IceMiningRig As Boolean

    Dim RefiningEfficiency As Double
    Dim RefiningTax As Double
    Dim RefineCorpStanding As Double

    Dim ColumnSort As Integer
    Dim ColumnSortType As String

End Structure

' If we show these columns or not
Public Structure IndustryJobsColumnSettings

    ' These are the column orders and shown/not shown. 0 is not shown, else the order number
    Dim JobState As Integer
    Dim InstallerName As Integer
    Dim TimeToComplete As Integer
    Dim Activity As Integer
    Dim Status As Integer
    Dim StartTime As Integer
    Dim EndTime As Integer
    Dim CompletionTime As Integer
    Dim Blueprint As Integer
    Dim OutputItem As Integer
    Dim OutputItemType As Integer
    Dim InstallSystem As Integer
    Dim InstallRegion As Integer
    Dim LicensedRuns As Integer
    Dim Runs As Integer
    Dim SuccessfulRuns As Integer
    Dim BlueprintLocation As Integer
    Dim OutputLocation As Integer
    Dim JobType As Integer ' Personal or Corp

    Dim JobStateWidth As Integer
    Dim InstallerNameWidth As Integer
    Dim TimeToCompleteWidth As Integer
    Dim ActivityWidth As Integer
    Dim StatusWidth As Integer
    Dim StartTimeWidth As Integer
    Dim EndTimeWidth As Integer
    Dim CompletionTimeWidth As Integer
    Dim BlueprintWidth As Integer
    Dim OutputItemWidth As Integer
    Dim OutputItemTypeWidth As Integer
    Dim InstallSystemWidth As Integer
    Dim InstallRegionWidth As Integer
    Dim LicensedRunsWidth As Integer
    Dim RunsWidth As Integer
    Dim SuccessfulRunsWidth As Integer
    Dim BlueprintLocationWidth As Integer
    Dim OutputLocationWidth As Integer
    Dim JobTypeWidth As Integer ' Personal or Corp

    Dim OrderByColumn As Integer ' What column index the jobs are sorted
    Dim OrderType As String ' Ascending or Descending

    Dim ViewJobType As String ' Personal, Corp, or Both

    Dim JobTimes As String ' Current or History

    ' List of selected characters, comma separated - default is going to be empty but will automatically choose the selected character
    Dim SelectedCharacterIDs As String

    ' Whether we automatically update jobs every time they open the window - if not checked, they need to hit 'Update Jobs'
    Dim AutoUpdateJobs As Boolean

End Structure

' If we show these columns or not
Public Structure ManufacturingTabColumnSettings

    ' These are the column orders and shown/not shown. 0 is not shown so it can be used for the order number
    Dim ItemCategory As Integer
    Dim ItemGroup As Integer
    Dim ItemName As Integer
    Dim Owned As Integer
    Dim Tech As Integer
    Dim BPME As Integer
    Dim BPTE As Integer
    Dim Inputs As Integer
    Dim Compared As Integer
    Dim TotalRuns As Integer
    Dim SingleInventedBPCRuns As Integer
    Dim ProductionLines As Integer
    Dim LaboratoryLines As Integer
    Dim TotalInventionCost As Integer
    Dim TotalCopyCost As Integer
    Dim Taxes As Integer
    Dim BrokerFees As Integer
    Dim BPProductionTime As Integer
    Dim TotalProductionTime As Integer
    Dim CopyTime As Integer
    Dim InventionTime As Integer
    Dim ItemMarketPrice As Integer
    Dim Profit As Integer
    Dim ProfitPercentage As Integer
    Dim IskperHour As Integer
    Dim SVR As Integer
    Dim SVRxIPH As Integer
    Dim PriceTrend As Integer
    Dim TotalItemsSold As Integer
    Dim TotalOrdersFilled As Integer
    Dim AvgItemsperOrder As Integer
    Dim CurrentSellOrders As Integer
    Dim CurrentBuyOrders As Integer
    Dim ItemsinProduction As Integer
    Dim ItemsinStock As Integer
    Dim TotalCost As Integer
    Dim BaseJobCost As Integer
    Dim NumBPs As Integer
    Dim InventionChance As Integer
    Dim BPType As Integer
    Dim Race As Integer
    Dim VolumeperItem As Integer
    Dim TotalVolume As Integer
    Dim PortionSize As Integer
    Dim ManufacturingJobFee As Integer
    Dim ManufacturingFacilityName As Integer
    Dim ManufacturingFacilitySystem As Integer
    Dim ManufacturingFacilityRegion As Integer
    Dim ManufacturingFacilitySystemIndex As Integer
    Dim ManufacturingFacilityTax As Integer
    Dim ManufacturingFacilityMEBonus As Integer
    Dim ManufacturingFacilityTEBonus As Integer
    Dim ManufacturingFacilityUsage As Integer
    Dim ManufacturingFacilityFWSystemLevel As Integer
    Dim ComponentFacilityName As Integer
    Dim ComponentFacilitySystem As Integer
    Dim ComponentFacilityRegion As Integer
    Dim ComponentFacilitySystemIndex As Integer
    Dim ComponentFacilityTax As Integer
    Dim ComponentFacilityMEBonus As Integer
    Dim ComponentFacilityTEBonus As Integer
    Dim ComponentFacilityUsage As Integer
    Dim ComponentFacilityFWSystemLevel As Integer
    Dim CapComponentFacilityName As Integer
    Dim CapComponentFacilitySystem As Integer
    Dim CapComponentFacilityRegion As Integer
    Dim CapComponentFacilitySystemIndex As Integer
    Dim CapComponentFacilityTax As Integer
    Dim CapComponentFacilityMEBonus As Integer
    Dim CapComponentFacilityTEBonus As Integer
    Dim CapComponentFacilityUsage As Integer
    Dim CapComponentFacilityFWSystemLevel As Integer
    Dim CopyingFacilityName As Integer
    Dim CopyingFacilitySystem As Integer
    Dim CopyingFacilityRegion As Integer
    Dim CopyingFacilitySystemIndex As Integer
    Dim CopyingFacilityTax As Integer
    Dim CopyingFacilityMEBonus As Integer
    Dim CopyingFacilityTEBonus As Integer
    Dim CopyingFacilityUsage As Integer
    Dim CopyingFacilityFWSystemLevel As Integer
    Dim InventionFacilityName As Integer
    Dim InventionFacilitySystem As Integer
    Dim InventionFacilityRegion As Integer
    Dim InventionFacilitySystemIndex As Integer
    Dim InventionFacilityTax As Integer
    Dim InventionFacilityMEBonus As Integer
    Dim InventionFacilityTEBonus As Integer
    Dim InventionFacilityUsage As Integer
    Dim InventionFacilityFWSystemLevel As Integer
    Dim ReactionFacilityName As Integer
    Dim ReactionFacilitySystem As Integer
    Dim ReactionFacilityRegion As Integer
    Dim ReactionFacilitySystemIndex As Integer
    Dim ReactionFacilityTax As Integer
    Dim ReactionFacilityMEBonus As Integer
    Dim ReactionFacilityTEBonus As Integer
    Dim ReactionFacilityUsage As Integer
    Dim ReactionFacilityFWSystemLevel As Integer

    Dim ItemCategoryWidth As Integer
    Dim ItemGroupWidth As Integer
    Dim ItemNameWidth As Integer
    Dim OwnedWidth As Integer
    Dim TechWidth As Integer
    Dim BPMEWidth As Integer
    Dim BPTEWidth As Integer
    Dim InputsWidth As Integer
    Dim ComparedWidth As Integer
    Dim TotalRunsWidth As Integer
    Dim SingleInventedBPCRunsWidth As Integer
    Dim ProductionLinesWidth As Integer
    Dim LaboratoryLinesWidth As Integer
    Dim TotalInventionCostWidth As Integer
    Dim TotalCopyCostWidth As Integer
    Dim TaxesWidth As Integer
    Dim BrokerFeesWidth As Integer
    Dim BPProductionTimeWidth As Integer
    Dim TotalProductionTimeWidth As Integer
    Dim CopyTimeWidth As Integer
    Dim InventionTimeWidth As Integer
    Dim ItemMarketPriceWidth As Integer
    Dim ProfitWidth As Integer
    Dim ProfitPercentageWidth As Integer
    Dim IskperHourWidth As Integer
    Dim SVRWidth As Integer
    Dim SVRxIPHWidth As Integer
    Dim PriceTrendWidth As Integer
    Dim TotalItemsSoldWidth As Integer
    Dim TotalOrdersFilledWidth As Integer
    Dim AvgItemsperOrderWidth As Integer
    Dim CurrentSellOrdersWidth As Integer
    Dim CurrentBuyOrdersWidth As Integer
    Dim ItemsinProductionWidth As Integer
    Dim ItemsinStockWidth As Integer
    Dim TotalCostWidth As Integer
    Dim BaseJobCostWidth As Integer
    Dim NumBPsWidth As Integer
    Dim InventionChanceWidth As Integer
    Dim BPTypeWidth As Integer
    Dim RaceWidth As Integer
    Dim VolumeperItemWidth As Integer
    Dim TotalVolumeWidth As Integer
    Dim PortionSizeWidth As Integer
    Dim ManufacturingJobFeeWidth As Integer
    Dim ManufacturingFacilityNameWidth As Integer
    Dim ManufacturingFacilitySystemWidth As Integer
    Dim ManufacturingFacilityRegionWidth As Integer
    Dim ManufacturingFacilitySystemIndexWidth As Integer
    Dim ManufacturingFacilityTaxWidth As Integer
    Dim ManufacturingFacilityMEBonusWidth As Integer
    Dim ManufacturingFacilityTEBonusWidth As Integer
    Dim ManufacturingFacilityUsageWidth As Integer
    Dim ManufacturingFacilityFWSystemLevelWidth As Integer
    Dim ComponentFacilityNameWidth As Integer
    Dim ComponentFacilitySystemWidth As Integer
    Dim ComponentFacilityRegionWidth As Integer
    Dim ComponentFacilitySystemIndexWidth As Integer
    Dim ComponentFacilityTaxWidth As Integer
    Dim ComponentFacilityMEBonusWidth As Integer
    Dim ComponentFacilityTEBonusWidth As Integer
    Dim ComponentFacilityUsageWidth As Integer
    Dim ComponentFacilityFWSystemLevelWidth As Integer
    Dim CapComponentFacilityNameWidth As Integer
    Dim CapComponentFacilitySystemWidth As Integer
    Dim CapComponentFacilityRegionWidth As Integer
    Dim CapComponentFacilitySystemIndexWidth As Integer
    Dim CapComponentFacilityTaxWidth As Integer
    Dim CapComponentFacilityMEBonusWidth As Integer
    Dim CapComponentFacilityTEBonusWidth As Integer
    Dim CapComponentFacilityUsageWidth As Integer
    Dim CapComponentFacilityFWSystemLevelWidth As Integer
    Dim CopyingFacilityNameWidth As Integer
    Dim CopyingFacilitySystemWidth As Integer
    Dim CopyingFacilityRegionWidth As Integer
    Dim CopyingFacilitySystemIndexWidth As Integer
    Dim CopyingFacilityTaxWidth As Integer
    Dim CopyingFacilityMEBonusWidth As Integer
    Dim CopyingFacilityTEBonusWidth As Integer
    Dim CopyingFacilityUsageWidth As Integer
    Dim CopyingFacilityFWSystemLevelWidth As Integer
    Dim InventionFacilityNameWidth As Integer
    Dim InventionFacilitySystemWidth As Integer
    Dim InventionFacilityRegionWidth As Integer
    Dim InventionFacilitySystemIndexWidth As Integer
    Dim InventionFacilityTaxWidth As Integer
    Dim InventionFacilityMEBonusWidth As Integer
    Dim InventionFacilityTEBonusWidth As Integer
    Dim InventionFacilityUsageWidth As Integer
    Dim InventionFacilityFWSystemLevelWidth As Integer
    Dim ReactionFacilityNameWidth As Integer
    Dim ReactionFacilitySystemWidth As Integer
    Dim ReactionFacilityRegionWidth As Integer
    Dim ReactionFacilitySystemIndexWidth As Integer
    Dim ReactionFacilityTaxWidth As Integer
    Dim ReactionFacilityMEBonusWidth As Integer
    Dim ReactionFacilityTEBonusWidth As Integer
    Dim ReactionFacilityUsageWidth As Integer
    Dim ReactionFacilityFWSystemLevelWidth As Integer

    Dim OrderByColumn As Integer ' What column index the jobs are sorted
    Dim OrderType As String ' Ascending or Descending

    Dim Volatility As Integer
    Dim VolatilityWidth As Integer
    Dim Score As Integer
    Dim ScoreWidth As Integer
    Dim RiskProfit As Integer
    Dim RiskProfitWidth As Integer
    Dim RiskIPH As Integer
    Dim RiskIPHWidth As Integer
    Dim RiskPrice As Integer
    Dim RiskPriceWidth As Integer

End Structure

' For Main Industry Flip Belt Settings
Public Structure IndustryFlipBeltSettings
    Dim CycleTime As Double
    Dim m3perCycle As Double
    Dim NumMiners As Integer
    Dim CompressOre As Boolean
    Dim IPHperMiner As Boolean
    Dim IncludeBrokerFees As Integer
    Dim IncludeTaxes As Boolean
    Dim BrokerFeeRate As Double
    Dim TrueSec As String

    Dim RefiningEfficiency As Double
    Dim RefineCorpStanding As Double
    Dim RefiningTax As Double

End Structure

' For the checked ore on each mining tab
Public Structure IndustryBeltOreChecks
    Dim Plagioclase As Boolean
    Dim Spodumain As Boolean
    Dim Kernite As Boolean
    Dim Hedbergite As Boolean
    Dim Arkonor As Boolean
    Dim Bistot As Boolean
    Dim Pyroxeres As Boolean
    Dim Crokite As Boolean
    Dim Jaspet As Boolean
    Dim Omber As Boolean
    Dim Scordite As Boolean
    Dim Gneiss As Boolean
    Dim Veldspar As Boolean
    Dim Hemorphite As Boolean
    Dim DarkOchre As Boolean
    Dim Mercoxit As Boolean
    Dim CrimsonArkonor As Boolean
    Dim PrimeArkonor As Boolean
    Dim TriclinicBistot As Boolean
    Dim MonoclinicBistot As Boolean
    Dim SharpCrokite As Boolean
    Dim CrystallineCrokite As Boolean
    Dim OnyxOchre As Boolean
    Dim ObsidianOchre As Boolean
    Dim VitricHedbergite As Boolean
    Dim GlazedHedbergite As Boolean
    Dim VividHemorphite As Boolean
    Dim RadiantHemorphite As Boolean
    Dim PureJaspet As Boolean
    Dim PristineJaspet As Boolean
    Dim LuminousKernite As Boolean
    Dim FieryKernite As Boolean
    Dim AzurePlagioclase As Boolean
    Dim RichPlagioclase As Boolean
    Dim SolidPyroxeres As Boolean
    Dim ViscousPyroxeres As Boolean
    Dim CondensedScordite As Boolean
    Dim MassiveScordite As Boolean
    Dim BrightSpodumain As Boolean
    Dim GleamingSpodumain As Boolean
    Dim ConcentratedVeldspar As Boolean
    Dim DenseVeldspar As Boolean
    Dim IridescentGneiss As Boolean
    Dim PrismaticGneiss As Boolean
    Dim SilveryOmber As Boolean
    Dim GoldenOmber As Boolean
    Dim MagmaMercoxit As Boolean
    Dim VitreousMercoxit As Boolean
End Structure

' For Assets Selected Item Settings
Public Structure AssetWindowSettings

    ' Main window
    Dim AssetType As String
    Dim SortbyName As Boolean

    ' Selected Items
    Dim ItemFilterText As String
    Dim AllItems As Boolean

    Dim AllRawMats As Boolean
    Dim Minerals As Boolean
    Dim IceProducts As Boolean
    Dim Gas As Boolean
    Dim AbyssalMaterials As Boolean
    Dim Misc As Boolean
    Dim BPCs As Boolean
    Dim AncientRelics As Boolean
    Dim AncientSalvage As Boolean
    Dim Salvage As Boolean
    Dim Planetary As Boolean
    Dim Datacores As Boolean
    Dim Decryptors As Boolean
    Dim RawMats As Boolean
    Dim ProcessedMats As Boolean
    Dim AdvancedMats As Boolean
    Dim MatsandCompounds As Boolean
    Dim DroneComponents As Boolean
    Dim BoosterMats As Boolean
    Dim Polymers As Boolean
    Dim Asteroids As Boolean

    Dim AllManufacturedItems As Boolean
    Dim Ships As Boolean
    Dim Modules As Boolean
    Dim Drones As Boolean
    Dim Boosters As Boolean
    Dim Rigs As Boolean
    Dim Charges As Boolean
    Dim Subsystems As Boolean
    Dim Structures As Boolean
    Dim Tools As Boolean
    Dim DataInterfaces As Boolean
    Dim CapT2Components As Boolean
    Dim CapitalComponents As Boolean
    Dim Components As Boolean
    Dim Hybrid As Boolean
    Dim StructureComponents As Boolean
    Dim FuelBlocks As Boolean
    Dim StructureRigs As Boolean
    Dim StructureModules As Boolean
    Dim Celestials As Boolean
    Dim Deployables As Boolean
    Dim Implants As Boolean

    Dim T1 As Boolean
    Dim T2 As Boolean
    Dim T3 As Boolean
    Dim Faction As Boolean
    Dim Pirate As Boolean
    Dim Storyline As Boolean

End Structure

' For the Shopping List
Public Structure ShoppingListSettings
    Dim DataExportFormat As String
    Dim AlwaysonTop As Boolean
    Dim UpdateAssetsWhenUsed As Boolean
    Dim Fees As Boolean
    Dim CalcBuyBuyOrder As Integer
    Dim Usage As Boolean
    Dim ReloadBPsFromFile As Boolean
End Structure

' For the BP Viewer
Public Structure BPViewerSettings
    Dim BlueprintTypeSelection As String ' Saves the name of the radio button used

    Dim BPNPCBPOsCheck As Boolean

    Dim Tech1Check As Boolean
    Dim Tech2Check As Boolean
    Dim Tech3Check As Boolean
    Dim TechStorylineCheck As Boolean
    Dim TechFactionCheck As Boolean
    Dim TechPirateCheck As Boolean

    Dim IncludeIgnoredBPs As Boolean

    Dim SmallCheck As Boolean
    Dim MediumCheck As Boolean
    Dim LargeCheck As Boolean
    Dim XLCheck As Boolean
End Structure

' Settings on LP Store form
Public Structure LPStore
    Dim RewardType As String
    Dim CorpFilter As String

    Dim CheckAgentLevel1 As Boolean
    Dim CheckAgentLevel2 As Boolean
    Dim CheckAgentLevel3 As Boolean
    Dim CheckAgentLevel4 As Boolean
    Dim CheckAgentLevel5 As Boolean

    Dim TextItemSearch As String

    Dim LPCostLessThan As String
    Dim LPCostGreaterThan As String
    Dim ISKCostLessThan As String
    Dim ISKCostGreaterThan As String
    Dim StandingLessThan As String
    Dim StandingGreaterThan As String

    Dim SearchOption As String
    Dim SortByOption As String

    Dim HighlightCheck As Boolean

    Dim SelectedCorporations As String ' CSV string with all the corp names checked

End Structure

' For Upwell Structures fitting window
Public Structure UpwellStructureSettings
    Dim HighSlotsCheck As Boolean
    Dim MediumSlotsCheck As Boolean
    Dim LowSlotsCheck As Boolean
    Dim ServicesCheck As Boolean
    Dim ReprocessingRigsCheck As Boolean
    Dim EngineeringRigsCheck As Boolean
    Dim CombatRigsCheck As Boolean
    Dim ReactionsRigsCheck As Boolean
    Dim DrillingRigsCheck As Boolean

    Dim IncludeFuelCostsCheck As Boolean
    Dim FuelBlockType As String
    Dim BuyBuildBlockOption As String
    Dim AutoUpdateFuelBlockPricesCheck As Boolean
    Dim SearchFilterText As String
    Dim SelectedStructureName As String

    Dim IconListView As Boolean

End Structure

' For structure bonus viewing
Public Structure StructureBonusPopoutSettings
    Dim FormWidth As Integer
    Dim FormHeight As Integer
    Dim BonusAppliesColumnWidth As Integer
    Dim ActivityColumnWidth As Integer
    Dim BonusesColumnWidth As Integer
    Dim BonusSourceColumnWidth As Integer
End Structure