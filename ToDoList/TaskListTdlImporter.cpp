// TaskListCsvImporter.cpp: implementation of the CTaskListTdlImporter class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "TaskListTdlImporter.h"
#include "TDLTasklistImportDlg.h"
#include "Taskfile.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CTaskListTdlImporter::CTaskListTdlImporter()
{

}

CTaskListTdlImporter::~CTaskListTdlImporter()
{

}

IIMPORTEXPORT_RESULT CTaskListTdlImporter::Import(LPCTSTR szSrcFilePath, ITaskList* pDestTaskFile, bool bSilent, IPreferences* /*pPrefs*/, LPCTSTR /*szKey*/)
{
	if (pDestTaskFile == NULL)
	{
		ASSERT(0);
		return IIER_BADINTERFACE;
	}
	
	if (!bSilent)
	{
		CTDLTasklistImportDlg dialog(szSrcFilePath);
		
		if (dialog.DoModal() != IDOK)
			return IIER_CANCELLED;

		// else
		return dialog.GetSelectedTasks(pDestTaskFile);
	}

	// else 
	CTaskFile tasks;

	if (!tasks.Load(szSrcFilePath))
	{
		switch (tasks.GetLastFileError())
		{
		case XFL_CANCELLED: 
			return IIER_CANCELLED;

		case XFL_BADMSXML:
		case XFL_MISSINGROOT: 
			return IIER_BADFORMAT;
		}

		return IIER_OTHER;
	}

	if (!tasks.CopyTasksTo(pDestTaskFile))
		return IIER_SOMEFAILED;

	return IIER_SUCCESS;
}

