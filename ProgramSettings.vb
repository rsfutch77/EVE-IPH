
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
    ' Manufacturing
    Public UserManufacturingTabSettings As ManufacturingTabSettings
    ' Update Prices Tab Settings
    Public UserUpdatePricesTabSettings As UpdatePriceTabSettings
    ' Manufacturing Tab Column Settings
    Public UserManufacturingTabColumnSettings As ManufacturingTabColumnSettings
    ' Shopping List settings
    Public UserShoppingListSettings As ShoppingListSettings

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
    Public DefaultPriceChecks As Boolean = True
    Public DefaultPriceSystem As String = "Jita"
    Public DefaultPriceRegion As String = "The Forge"
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
    Public DefaultCheckAutoShop As Boolean = False
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
    Private DefaultIncludeBrokerFees As Integer '0,1,2 - Tri-check
    Private DefaultBFBrokerFeeRate As Double = 0.05
    Private DefaultIncludeTaxes As Boolean = True

    ' Default Shopping List Settings
    Private DefaultAlwaysonTop As Boolean = False
    Private DefaultUpdateAssetsWhenUsed As Boolean = False
    Private DefaultFees As Boolean = True
    Private DefaultCalcBuyBuyOrder As Integer = 1
    Private DefaultUsage As Boolean = True
    Private DefaultReloadBPsFromFile As Boolean = True

    ' Local versions of settings
    Private ApplicationSettings As ApplicationSettings
    Private BPSettings As BPTabSettings
    Private ManufacturingSettings As ManufacturingTabSettings
    Private UpdatePricesSettings As UpdatePriceTabSettings
    Private ManufacturingTabColumnSettings As ManufacturingTabColumnSettings
    Private ShoppingListTabSettings As ShoppingListSettings

    Private Const AppSettingsFileName As String = "ApplicationSettings"
    Private Const BPSettingsFileName As String = "BPTabSettings"
    Private Const ManufacturingSettingsFileName As String = "ManufacturingTabSettings"
    Private Const UpdatePricesFileName As String = "UpdatePricesSettings"
    Private Const IndustryJobsColumnSettingsFileName As String = "IndustryJobsColumnSettings"
    Private Const ShoppingListSettingsFileName As String = "ShoppingListSettings"

    Private Const XMLfileType As String = ".xml"

    Public Sub New()
        ApplicationSettings = Nothing
        ManufacturingSettings = Nothing
        UpdatePricesSettings = Nothing
        ManufacturingTabColumnSettings = Nothing
        ShoppingListTabSettings = Nothing

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
                    .DataExportFormat = CStr(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeString, AppSettingsFileName, "DataExportFormat", DefaultDataExportFormat))
                    .AllowSkillOverride = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AllowSkillOverride", DefaultAllowSkillOverride))
                    .ManufacturingImplantValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "ManufacturingImplantValue", DefaultImplantValues))
                    .BrokerCorpStanding = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerCorpStanding", DefaultBrokerCorpStanding))
                    .BrokerFactionStanding = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerFactionStanding", DefaultBrokerFactionStanding))
                    .DefaultBPME = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPME", DefaultSettingME))
                    .DefaultBPTE = CInt(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPTE", DefaultSettingTE))
                    .CheckBuildBuy = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "CheckBuildBuy", DefaultCheckBuildBuy))
                    .DisableGATracking = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableGATracking", DefaultDisableGATracking))
                    .SuggestBuildBPNotOwned = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "SuggestBuildBPNotOwned", DefaultSuggestBuildBPNotOwned))
                    .IgnoreSVRThresholdValue = CDbl(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeDouble, AppSettingsFileName, "IgnoreSVRThresholdValue", DefaultIgnoreSVRThresholdValue))
                    .AutoUpdateSVRonBPTab = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AutoUpdateSVRonBPTab", DefaultAutoUpdateSVRonBPTab))
                    .AlphaAccount = CBool(GetSettingValue(SettingsFolder, AppSettingsFileName, SettingTypes.TypeBoolean, AppSettingsFileName, "AlphaAccount", DefaultAlphaAccount))
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
            .DataExportFormat = DefaultDataExportFormat
            .ManufacturingImplantValue = DefaultImplantValues

            ' Station Standings for building and selling
            .BrokerCorpStanding = DefaultBrokerCorpStanding
            .BrokerFactionStanding = DefaultBrokerFactionStanding

            .CheckBuildBuy = DefaultCheckBuildBuy

            .DefaultBPME = DefaultSettingME
            .DefaultBPTE = DefaultSettingTE

            .AlphaAccount = DefaultAlphaAccount

            .DisableGATracking = DefaultDisableGATracking
            .SuggestBuildBPNotOwned = DefaultSuggestBuildBPNotOwned
            .IgnoreSVRThresholdValue = DefaultIgnoreSVRThresholdValue
            .AutoUpdateSVRonBPTab = DefaultAutoUpdateSVRonBPTab

        End With

        ' Save locally
        ApplicationSettings = TempSettings
        Return TempSettings

    End Function

    ' Saves the application settings to XML
    Public Sub SaveApplicationSettings(SentSettings As ApplicationSettings)
        Dim ApplicationSettingsList(12) As Setting

        Try
            ApplicationSettingsList(0) = New Setting("AlphaAccount", CStr(SentSettings.AlphaAccount))
            ApplicationSettingsList(1) = New Setting("DataExportFormat", CStr(SentSettings.DataExportFormat))
            ApplicationSettingsList(2) = New Setting("AllowSkillOverride", CStr(SentSettings.AllowSkillOverride))
            ApplicationSettingsList(3) = New Setting("ManufacturingImplantValue", CStr(SentSettings.ManufacturingImplantValue))
            ApplicationSettingsList(4) = New Setting("BrokerCorpStanding", CStr(SentSettings.BrokerCorpStanding))
            ApplicationSettingsList(5) = New Setting("BrokerFactionStanding", CStr(SentSettings.BrokerFactionStanding))
            ApplicationSettingsList(6) = New Setting("DefaultBPME", CStr(SentSettings.DefaultBPME))
            ApplicationSettingsList(7) = New Setting("DefaultBPTE", CStr(SentSettings.DefaultBPTE))
            ApplicationSettingsList(8) = New Setting("CheckBuildBuy", CStr(SentSettings.CheckBuildBuy))
            ApplicationSettingsList(9) = New Setting("SuggestBuildBPNotOwned", CStr(SentSettings.SuggestBuildBPNotOwned))
            ApplicationSettingsList(10) = New Setting("IgnoreSVRThresholdValue", CStr(SentSettings.IgnoreSVRThresholdValue))
            ApplicationSettingsList(11) = New Setting("AutoUpdateSVRonBPTab", CStr(SentSettings.AutoUpdateSVRonBPTab))
            ApplicationSettingsList(12) = New Setting("DisableGATracking", CStr(SentSettings.DisableGATracking))

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

                    .SelectedRegion = CStr(GetSettingValue(SettingsFolder, UpdatePricesFileName, SettingTypes.TypeString, UpdatePricesFileName, "SelectedRegion", DefaultPriceRegion))
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

            UpdatePricesSettingsList(39) = New Setting("SelectedRegion", PriceSettings.SelectedRegion)
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
            .SelectedRegion = DefaultPriceRegion
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
                    .CheckAutoShop = CBool(GetSettingValue(SettingsFolder, ManufacturingSettingsFileName, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckAutoShop", DefaultCheckAutoShop))

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
            .CheckAutoShop = DefaultCheckAutoShop
            .CheckOnlyInvent = DefaultCheckOnlyInvent
            .CheckIncludeTaxes = DefaultCheckIncludeTaxes
            .CheckIncludeBrokersFees = DefaultIncludeBrokersFees
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
        Dim ManufacturingSettingsList(93) As Setting

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
            ManufacturingSettingsList(87) = New Setting("BuildT2T3Materials", CStr(SentSettings.BuildT2T3Materials))
            ManufacturingSettingsList(88) = New Setting("Volatility", CStr(SentSettings.Volatility))
            ManufacturingSettingsList(89) = New Setting("Score", CStr(SentSettings.Score))
            ManufacturingSettingsList(90) = New Setting("RiskIPH", CStr(SentSettings.RiskIPH))
            ManufacturingSettingsList(91) = New Setting("RiskProfit", CStr(SentSettings.RiskProfit))
            ManufacturingSettingsList(92) = New Setting("RiskPrice", CStr(SentSettings.RiskPrice))
            ManufacturingSettingsList(93) = New Setting("CheckAutoShop", CStr(SentSettings.CheckAutoShop))

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

#Region "Manufacturing Tab Column Settings"

    ' Loads the tab settings
    Public Function LoadManufacturingTabColumnSettings() As ManufacturingTabColumnSettings
        Dim TempSettings As ManufacturingTabColumnSettings = Nothing

        'Get the settings
        With TempSettings
            .ItemCategory = 1
            .ItemName = 2
            .BPME = 3
            .BPTE = 4
            .CurrentSellOrders = 5
            .ItemsinProduction = 6
            .ItemsinStock = 7
            .Volatility = 8
            .PriceTrend = 9
            .SVR = 10
            .IskperHour = 11
            .RiskIPH = 12
            .Score = 13

            .ItemCategoryWidth = 100
            .ItemNameWidth = 100
            .BPMEWidth = 100
            .BPTEWidth = 100
            .CurrentSellOrdersWidth = 100
            .ItemsinProductionWidth = 100
            .ItemsinStockWidth = 100
            .VolatilityWidth = 100
            .PriceTrendWidth = 100
            .SVRWidth = 100
            .IskperHourWidth = 100
            .RiskIPHWidth = 100
            .ScoreWidth = 100

            .OrderByColumn = 13
            .OrderType = "Descending"

        End With

        Return TempSettings

    End Function

#End Region

End Class

' For general program settings
Public Structure ApplicationSettings
    Dim DataExportFormat As String
    Dim AllowSkillOverride As Boolean

    Dim ManufacturingImplantValue As Double

    ' Station Standings for building and selling
    Dim BrokerCorpStanding As Double
    Dim BrokerFactionStanding As Double

    ' ME/TE for BP's we don't own or haven't entered info for
    Dim DefaultBPME As Integer
    Dim DefaultBPTE As Integer

    ' For Build/Buy 
    Dim CheckBuildBuy As Boolean ' Default for setting the check box for build/buy on the blueprints screen
    Dim SuggestBuildBPNotOwned As Boolean ' For Build/Buy suggestions

    Dim DisableGATracking As Boolean ' for disabling tracking app usage through Google Analytics

    ' Character options
    Dim AlphaAccount As Boolean ' Check to determine if they are using an alpha account or not

    ' Filter variables for svr
    Dim IgnoreSVRThresholdValue As Double
    Dim AutoUpdateSVRonBPTab As Boolean

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

    Dim SelectedRegion As String
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
    Dim CheckAutoShop As Boolean
    Dim CheckOnlyInvent As Boolean

    Dim CheckIncludeTaxes As Boolean
    Dim CheckIncludeBrokersFees As Integer ' Tri check
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