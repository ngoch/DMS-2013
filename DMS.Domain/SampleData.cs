using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMS.Domain
{
    public class SampleData : DropCreateDatabaseAlways<DMSDbContext>
    {
        protected override void Seed(DMSDbContext context)
        {
            var projects = new List<Project> 
            { 
                 new Project { ProjectName="Prj1"},
            };


            var symptoms = new List<Symptom> {             
                    new Symptom{SymptomName="a", Project=projects.Single(p=>p.ProjectName=="Prj1")},
                    new Symptom{SymptomName="b", Project=projects.Single(p=>p.ProjectName=="Prj1")},
                    new Symptom{SymptomName="c", Project=projects.Single(p=>p.ProjectName=="Prj1")},
                    new Symptom{SymptomName="d", Project=projects.Single(p=>p.ProjectName=="Prj1")},
                    new Symptom{SymptomName="e", Project=projects.Single(p=>p.ProjectName=="Prj1")},
                    new Symptom{SymptomName="f", Project=projects.Single(p=>p.ProjectName=="Prj1")},
            };

            var diagnoses = new List<Diagnosis> {             
                    new Diagnosis{DiagnosisName="D1"},
                    new Diagnosis{DiagnosisName="D2"}
        };

            new List<Interval>{

                    new Interval
                    {  
                        Alfa=1.00,
                        Diagnosis=diagnoses.Single(d=>d.DiagnosisName=="D1"),   
                        Symptoms=new List<Symptom>
                        {
                            symptoms.Single(s=>s.SymptomName=="d" )                  
                        }                    
                    },
                       new Interval
                    {  
                         Alfa=0.80,
                        Diagnosis=diagnoses.Single(d=>d.DiagnosisName=="D1"),   
                        Symptoms=new List<Symptom>
                        {
                            symptoms.Single(s=>s.SymptomName=="d" ),
                            symptoms.Single(s=>s.SymptomName=="b" )                 
                        }                    
                    },
                       new Interval
                    {  
                        Alfa=0.60,
                        Diagnosis=diagnoses.Single(d=>d.DiagnosisName=="D1"),   
                        Symptoms=new List<Symptom>
                        {
                            symptoms.Single(s=>s.SymptomName=="e" ),
                            symptoms.Single(s=>s.SymptomName=="b" ),
                            symptoms.Single(s=>s.SymptomName=="d" )                    
                        }                    
                    },
                       new Interval
                    {  
                        Alfa=0.40,
                        Diagnosis=diagnoses.Single(d=>d.DiagnosisName=="D1"),   
                        Symptoms=new List<Symptom>
                        {
                            symptoms.Single(s=>s.SymptomName=="a" ),
                            symptoms.Single(s=>s.SymptomName=="b" ),
                            symptoms.Single(s=>s.SymptomName=="c" ),
                            symptoms.Single(s=>s.SymptomName=="d" ),
                            symptoms.Single(s=>s.SymptomName=="e" )             
                        }                    
                    },
                       new Interval
                    {  
                        Alfa=0.20,
                        Diagnosis=diagnoses.Single(d=>d.DiagnosisName=="D1"),   
                        Symptoms=new List<Symptom>
                        {
                            symptoms.Single(s=>s.SymptomName=="a" ),
                            symptoms.Single(s=>s.SymptomName=="b" ),
                            symptoms.Single(s=>s.SymptomName=="c" ),    
                            symptoms.Single(s=>s.SymptomName=="d" ),
                            symptoms.Single(s=>s.SymptomName=="e" ),
                            symptoms.Single(s=>s.SymptomName=="f" )                  
                        }                    
                    }
            }.ForEach(a => context.Intervals.Add(a));
        }
    }
}