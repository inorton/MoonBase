
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/ViewLoader.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

VIEWLOADER_DLL_MDB_SOURCE=bin/Debug/ViewLoader.dll.mdb
VIEWLOADER_DLL_MDB=$(BUILD_DIR)/ViewLoader.dll.mdb
MOON_WINDOWS_DESKTOP_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll
SYSTEM_WINDOWS_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.Browser.dll
MOONLIGHT_GTK_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/ViewLoader.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

VIEWLOADER_DLL_MDB=
MOON_WINDOWS_DESKTOP_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll
SYSTEM_WINDOWS_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.Browser.dll
MOONLIGHT_GTK_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(VIEWLOADER_DLL_MDB) \
	$(MOON_WINDOWS_DESKTOP_DLL) \
	$(SYSTEM_WINDOWS_DLL) \
	$(SYSTEM_WINDOWS_BROWSER_DLL) \
	$(MOONLIGHT_GTK_DLL)  

LINUX_PKGCONFIG = \
	$(VIEWLOADER_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES =  \
	AssemblyInfo.cs \
	ViewLoader.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	viewloader.pc.in 

REFERENCES =  \
	../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll \
	../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../usr/lib/mono/moonlight/System.Windows.dll \
	System

DLL_REFERENCES =  \
	../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll \
	../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../usr/lib/mono/moonlight/System.Windows.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

MOON_WINDOWS_DESKTOP_DLL = $(BUILD_DIR)/Moon.Windows.Desktop.dll
SYSTEM_WINDOWS_DLL = $(BUILD_DIR)/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL = $(BUILD_DIR)/System.Windows.Browser.dll
MOONLIGHT_GTK_DLL = $(BUILD_DIR)/Moonlight.Gtk.dll
VIEWLOADER_PC = $(BUILD_DIR)/viewloader.pc

$(eval $(call emit-deploy-target,MOON_WINDOWS_DESKTOP_DLL))
$(eval $(call emit-deploy-target,SYSTEM_WINDOWS_DLL))
$(eval $(call emit-deploy-target,SYSTEM_WINDOWS_BROWSER_DLL))
$(eval $(call emit-deploy-target,MOONLIGHT_GTK_DLL))
$(eval $(call emit-deploy-wrapper,VIEWLOADER_PC,viewloader.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
